using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Results;

namespace InGreed_API.Services.UserService
{
    public interface IUserService
    {
        Task<LoginResult> Login(LoginRequest loginRequest);
        Task<LoginResult> Register(RegistrationRequest registerRequest);
        Task<ResultBase> BanUser(BanRequest banRequest);
    }
}
