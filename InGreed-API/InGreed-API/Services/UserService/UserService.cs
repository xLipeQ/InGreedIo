using InGreed_API.DataContext;
using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Results;
using InGreed_API.Factories;
using InGreed_API.Hubs;
using InGreed_API.Models;
using InGreed_API.Services.AuthService;
using InGreed_API.Services.CacheService.cs;
using InGreed_API.Services.JwtService;
using InGreed_API.Services.LogService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

namespace InGreed_API.Services.UserService
{
    public class UserService : IUserService
    {
        private IAuthService authService;
        private IJwtService jwtService;
        private InGreedDataContext inGreedDataContext;
        private IPasswordHasher<User> passwordHasher;
        private IHubContext<SignalrHub> hub;
        private ICacheService cache;
        private ILogService logService;

        public UserService(
            IAuthService _authService,
            IJwtService _jwtService,
            InGreedDataContext _inGreedDataContext,
            IPasswordHasher<User> _passwordHasher,
            IHubContext<SignalrHub> _hub,
            IConfiguration configuration,
            ILogService _logService)
        {
            authService = _authService;
            jwtService = _jwtService;
            inGreedDataContext = _inGreedDataContext;
            passwordHasher = _passwordHasher;
            hub = _hub;
            cache = CacheServiceFactory.GetFactory(configuration);
            logService = _logService;
        }

        public async Task<LoginResult> Login(LoginRequest loginRequest)
        {
            logService.Log($"Login - User: {loginRequest.Login}");

            LoginResult result;
            var authResult = await authService.AuthenticateUserAsyncUserAsync(loginRequest);

            if (authResult.Success)
                result = new LoginResult(jwtService.GenerateToken(authResult.User), true);
            else
                result = new LoginResult("", false, authResult.ErrorMessage);
            
            logService.Log($"User: {loginRequest.Login}", result);
            return result;
        }

        public async Task<LoginResult> Register(RegistrationRequest registerRequest)
        {
            logService.Log($"Registration - User: {registerRequest.Username}");

            LoginResult result;
            var user = await inGreedDataContext.Users
                .FirstOrDefaultAsync(u => u.Username == registerRequest.Username || u.Mail == registerRequest.Mail);

            if (user != null)
            {
                result = new LoginResult("", false, "User already exists");
            }
            else
            {
                user = new User()
                {
                    Username = registerRequest.Username,
                    Mail = registerRequest.Mail,
                    Role = registerRequest.Role
                };

                var passwordHash = passwordHasher.HashPassword(user, registerRequest.Password);
                user.PasswordHash = passwordHash;

                await inGreedDataContext.Users.AddAsync(user);
                await inGreedDataContext.SaveChangesAsync();

                var token = jwtService.GenerateToken(user);

                result =  new LoginResult(token, true);
            }

            logService.Log($"Registration - User: {registerRequest.Username}", result);

            return result;
        }

        public async Task<ResultBase> BanUser(BanRequest banRequest)
        {
            var ban = await inGreedDataContext.Bans
                .FirstOrDefaultAsync(b => b.UserId == banRequest.UserId);

            if (ban != null)
                return new ResultBase(false, "User is already banned");

            ban = new Ban()
            {
                UserId = banRequest.UserId,
                Reason = banRequest.Reason
            };

            await inGreedDataContext.AddAsync(ban);
            await inGreedDataContext.SaveChangesAsync();

            var connectionId = await cache.GetData<string>($"user_{banRequest.UserId}");

            if (!connectionId.IsNullOrEmpty())
            {
                await hub.Clients.Client(connectionId).SendAsync("Ban", banRequest.Reason);
            }
            return new ResultBase(true);
        }
    }
}
