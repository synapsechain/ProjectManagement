using Moq;
using Xunit;
using System;
using System.IO;
using OfficeOpenXml;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Tests.Utils;
using ProjectManagement.Api.Services;
using ProjectManagement.Api.Controllers;
using ProjectManagement.Api.Data;
using ProjectManagement.Api.Data.Entities;

namespace ProjectManagement.Tests
{
    public class FileControllerTests
    {
        [Fact]
        public async Task GetFile()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var dts = new Mock<IDateTimeService>();
            dts.Setup(x => x.UtcNow).Returns(new DateTime(2020, 4, 20));

            var db = UnitTestHelper.CreateInMemoryDb();
            await using (var context = db.CreateContext())
            {
                var task = DataSeeder.NewTask(3, 3);
                task.StartDate = new DateTime(2020, 4, 20);
                task.State = ItemState.InProgress;

                var project = DataSeeder.NewProject(3);
                project.State = ItemState.InProgress;

                context.Projects.Add(project);
                context.Projects.Add(DataSeeder.NewProject(6));
                context.Projects.Add(DataSeeder.NewProject(9));

                context.Tasks.Add(task);
                context.Tasks.Add(DataSeeder.NewTask(6, 6));
                context.Tasks.Add(DataSeeder.NewTask(9, 9));
                context.SaveChanges();
            }

            await using (var context = db.CreateContext())
            {
                var fileController = new ReportsController(dts.Object, new ReportGeneratorService(context, dts.Object));
                var file =
                    await fileController.Get(new DateTime(2020, 4, 20, 3, 3, 3)) as FileContentResult;
                file.Should().NotBeNull();

                await using var stream = new MemoryStream(file!.FileContents);
                using var package = new ExcelPackage(stream);
                
                package.Workbook.Worksheets.Count.Should().Be(1);
                var page = package.Workbook.Worksheets[0];
                page.Cells[ReportGeneratorService.START_ROW, ReportGeneratorService.START_COLUMN]
                    .Text.Should()
                    .Be("InProgress projects with tasks by 4/20/2020 3:03:03 AM. Report generated at 4/20/2020 12:00:00 AM");

                page.Dimension.Columns.Should().Be(6);
                page.Dimension.Rows.Should().Be(4);
            }
        }
    }
}
