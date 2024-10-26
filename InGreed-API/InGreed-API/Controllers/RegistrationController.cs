using InGreed_API.Dtos.Responses;
using InGreed_API.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Results;

namespace InGreed_API.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController(
        IUserService userService
        ) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            LoginResult response = await userService.Register(request);

            if (!response.Success)
                return Unauthorized(response.ErrorMessage);

            return Ok(new LoginResponse(response.JwtToken));
        }
    }
}
