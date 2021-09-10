using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Api.Services;
using ProjectManagement.Api.Tools;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportGeneratorService _reportGeneratorService;

        public ReportsController(IDateTimeService dts, IReportGeneratorService reportGeneratorService)
        {
            _reportGeneratorService = reportGeneratorService;
        }

        [HttpGet("simple")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<FileResult> Get(DateTime? dateTime)
        {
            var fileContents = await _reportGeneratorService.GenerateReportFile(dateTime).ConfigureAwait(false);

            return File(fileContents, Constants.ExcelContentType, $"report.{DateTime.UtcNow:dd.MM.yy.HH.mm}.xlsx");
        }
    }
}
