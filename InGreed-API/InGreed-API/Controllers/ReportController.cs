using InGreed_API.Services.OpinionService;
using InGreed_API.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InGreed_API.Dtos.Requests;
using InGreed_API.Services.ReportService;

namespace InGreed_API.Controllers
{
    [Route("api/[controller]")]
    public class ReportController(IReportService reportService) : Controller
    {
        [Authorize(Roles = nameof(UserRoleEnum.Administrator))]
        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            var reports = await reportService.GetReports();
            return Ok(reports);
        }

        [Authorize(Roles = nameof(UserRoleEnum.Client))]
        [HttpPost]
        public async Task<IActionResult> AddReport([FromBody] AddReportRequest reportRequest)
        {
            var result = await reportService.AddReport(reportRequest);

            if (result.Success)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = nameof(UserRoleEnum.Administrator))]
        [HttpDelete]
        public async Task<IActionResult> DeleteReport(int ReportId)
        {
            var result = await reportService.DeleteReport(ReportId);

            if (result.Success)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }
    }
}
