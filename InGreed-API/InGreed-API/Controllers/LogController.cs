using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Responses;
using InGreed_API.Dtos.Results;
using InGreed_API.Enums;
using InGreed_API.Services.LogService;
using InGreed_API.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InGreed_API.Controllers
{
    [Route("api/[Controller]")]
    public class LogController(
        ILogService logService
        ) : Controller
    {
        [HttpGet]
        [Authorize(Roles = nameof(UserRoleEnum.Administrator))]
        public async Task<IActionResult> LogFile(LogRequest request)
        {
            LogResult result = logService.GetLogFile(request);

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return File(result.Response.FileContent, result.Response.ContentType, result.Response.FileName);
        }
    }
}
