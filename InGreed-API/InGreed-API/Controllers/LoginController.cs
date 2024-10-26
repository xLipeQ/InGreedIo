using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Responses;
using InGreed_API.Dtos.Results;
using InGreed_API.Services.AuthService;
using InGreed_API.Services.JwtService;
using InGreed_API.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace InGreed_API.Controllers
{
    [Route("api/[Controller]")]
    public class LoginController(
        IUserService userService
        ) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            LoginResult response = await userService.Login(request);

            if (!response.Success)
                return Unauthorized(response.ErrorMessage);

            return Ok(new LoginResponse(response.JwtToken));
        }
    }
}