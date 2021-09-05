using System;
using System.Linq;
using OfficeOpenXml;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using ProjectManagement.Api.Tools;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Api.Data;
using ProjectManagement.Api.Models;
using ItemState = ProjectManagement.Api.Data.Entities.ItemState;
using Project = ProjectManagement.Api.Data.Entities.Project;
using ProjectTask = ProjectManagement.Api.Data.Entities.ProjectTask;

namespace ProjectManagement.Api.Services
{
    public interface IReportGeneratorService
    {
        Task<byte[]> GenerateReportFile(DateTime? datetime);
    }

    public class ReportGeneratorService : IReportGeneratorService
    {
        public const int START_ROW = 1;
        public const int START_COLUMN = 1;
        
        private readonly AppDbContext _context;
        private readonly IDateTimeService _dts;

        public ReportGeneratorService(AppDbContext context, IDateTimeService dts)
        {
            _context = context;
            _dts = dts;
        }

        public async Task<byte[]> GenerateReportFile(DateTime? dateTime)
        {
            dateTime ??= _dts.UtcNow;
            byte[] fileContents;

            Expression<Func<ProjectTask, bool>> taskSearch = x =>
                x.StartDate <= dateTime && 
                x.State == ItemState.InProgress;

            var tasks = await _context.ProjectTasks
                .Include(x => x.Project)
                .Where(taskSearch)
                .ToListAsync()
                .ConfigureAwait(false);

            var projects = tasks.Select(x => x.TopLevelProject!).Distinct();

            using var package = new ExcelPackage();
            var page = package.Workbook.Worksheets.Add("Report");
            var headerSize = WriteHeader(page, dateTime.Value);
            var records = new List<ExcelRecord>();
            var projectsIndexes = new List<int>();

            foreach (var project in projects)
            {
                WriteProjectToCollection(project, 0, records, projectsIndexes, taskSearch);
            }

            page.Cells[START_ROW + headerSize, START_COLUMN].LoadFromCollection(records, true, OfficeOpenXml.Table.TableStyles.Light12);

            MakeProjectsRowsBold(page, projectsIndexes, headerSize);
            MakeDateTimeColumnsCorrectlyFormatted(page);

            page.Cells[page.Dimension.Address].AutoFitColumns();

            fileContents = await package.GetAsByteArrayAsync().ConfigureAwait(false);

            return fileContents;
        }

        private int WriteHeader(ExcelWorksheet page, DateTime datetime)
        {
            var columnsCount = typeof(ExcelRecord).GetProperties().Length;
            var range = page.Cells[START_ROW, START_COLUMN, START_ROW, START_COLUMN + columnsCount - 1];
            range.Merge = true;
            range.Value = $"InProgress projects with tasks by {datetime}. Report generated at {_dts.UtcNow}";
            range.Style.Font.Bold = true;
            range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
            range.Style.Font.Color.SetColor(Color.Gray);
            page.Row(START_ROW).Height = 27;

            return 1;
        }

        private void WriteProjectToCollection(
            Project project,
            int level,
            List<ExcelRecord> records, //collection of data records that will be writed to file
            List<int> projectsIndexes, //indexes of rows with projects to mark them bold later
            Expression<Func<ProjectTask, bool>> taskSearch)
        {
            projectsIndexes.Add(records.Count);
            records.Add(project.ToExcelRecord(level));

            //add project tasks that fit search condition
            records.AddRange(project.Tasks.AsQueryable()
                .Where(taskSearch)
                .Select(x => x.ToExcelRecord(level + 1)));

            //add subprojects that contain specified tasks
            foreach (var subProject in project.Projects.Where(x => x.AllTasks.AsQueryable().Any(taskSearch)))
            {
                WriteProjectToCollection(subProject, level + 1, records, projectsIndexes, taskSearch);
            }
        }

        private void MakeProjectsRowsBold(ExcelWorksheet page, List<int> projectsIndexes, int indentRowsCount)
        {
            var tableHeaderRow = START_ROW + indentRowsCount;
            page.Row(tableHeaderRow).Style.Font.Bold = true;

            foreach (var idx in projectsIndexes)
            {
                page.Row(tableHeaderRow + idx + 1).Style.Font.Bold = true;
            }
        }

        private void MakeDateTimeColumnsCorrectlyFormatted(ExcelWorksheet page)
        {
            var properties = typeof(ExcelRecord).GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType == typeof(DateTime))
                    page.Column(START_COLUMN + i).Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
            }
        }
    }
}
