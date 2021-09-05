using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Api.Services;
using ProjectManagement.Api.Tools;

namespace ProjectManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IReportGeneratorService _reportGeneratorService;

        public FileController(IDateTimeService dts, IReportGeneratorService reportGeneratorService)
        {
            _reportGeneratorService = reportGeneratorService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        public async Task<FileResult> Get(DateTime? dateTime)
        {
            var fileContents = await _reportGeneratorService.GenerateReportFile(dateTime).ConfigureAwait(false);

            return File(fileContents, Constants.ExcelContentType, $"report.{DateTime.UtcNow:dd.MM.yy.HH.mm}.xlsx");
        }
    }
}
