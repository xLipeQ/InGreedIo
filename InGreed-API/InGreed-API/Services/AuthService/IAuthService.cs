using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Results;

namespace InGreed_API.Services.AuthService
{
    public interface IAuthService
    {
        Task<AuthResult> AuthenticateUserAsyncUserAsync(LoginRequest loginRequest);
    }
}
