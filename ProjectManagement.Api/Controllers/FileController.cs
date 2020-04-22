using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Api.Services;

namespace ProjectManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IDateTimeService _dts;
        private readonly IReportGeneratorService _reportGeneratorService;

        public FileController(IDateTimeService dts, IReportGeneratorService reportGeneratorService)
        {
            _dts = dts;
            _reportGeneratorService = reportGeneratorService;
        }

        [HttpGet]
        public async Task<FileResult> Get(DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                dateTime = _dts.Now;

            var fileContents = await _reportGeneratorService.GenerateReportFile(dateTime.Value);

            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report.xlsx");
        }
    }
}