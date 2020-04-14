using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Api.Services;
using ProjectManagement.Data.Contexts;
using ProjectManagement.Data.Entities;

namespace ProjectManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ProjectManagementContext _context;
        private readonly IDateTimeService _dts;
        private readonly IReportGeneratorService _reportGeneratorService;

        public FileController(ProjectManagementContext context, IDateTimeService dts, IReportGeneratorService reportGeneratorService)
        {
            _context = context;
            _dts = dts;
            _reportGeneratorService = reportGeneratorService;
        }

        [HttpGet]
        public async Task<FileResult> GetAsync(DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                dateTime = _dts.Now;

            Expression<Func<ProjectTask, bool>> taskSearch = x => x.StartDate <= dateTime && x.State == ItemState.InProgress;

            var tasks = await _context.ProjectTasks
                .Include(x => x.Project)
                .Where(taskSearch)
                .ToListAsync();

            var projects = tasks.Select(x => x.TopLevelProject).Distinct();

            var fileContents = await _reportGeneratorService.GenerateReportFileAsync(projects, dateTime.Value, taskSearch);

            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report.xlsx");
        }

    }
}