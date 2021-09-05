using System.Text;
using ProjectManagement.Api.Models;
using Project = ProjectManagement.Api.Data.Entities.Project;
using ProjectTask = ProjectManagement.Api.Data.Entities.ProjectTask;

namespace ProjectManagement.Api.Tools
{
    public static  class Extensions
    {
        public static ExcelRecord ToExcelRecord(this Project value, int level) =>
            new ExcelRecord
            {
                Id = value.Id,
                Name = value.Name.IndentValue(level),
                Description = value.Code,
                State = value.State.ToString(),
                StartDate = value.StartDate,
                FinishDate = value.FinishDate
            };

        public static ExcelRecord ToExcelRecord(this ProjectTask value, int level) =>
            new ExcelRecord
            {
                Id = value.Id,
                Name = value.Name.IndentValue(level),
                Description = value.Description.EmptyIfNull(),
                State = value.State.ToString(),
                StartDate = value.StartDate,
                FinishDate = value.FinishDate
            };

        public static string IndentValue(this string value, int level)
        {
            var res = new StringBuilder();

            for (int i = 0; i < level; i++)
            {
                res.Append("   ");
            }
            res.Append(value);

            return res.ToString();
        }

        public static string EmptyIfNull(this string? value) =>
            value ?? string.Empty;
    }
}
