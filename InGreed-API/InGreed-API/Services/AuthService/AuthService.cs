using InGreed_API.DataContext;
using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Results;
using InGreed_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InGreed_API.Services.AuthService
{
    public class AuthService(
        InGreedDataContext inGreedDataContext,
        IPasswordHasher<User> passwordHasher
        ) : IAuthService
    {
        public async Task<AuthResult> AuthenticateUserAsyncUserAsync(LoginRequest loginRequest)
        {
            var user = await inGreedDataContext.Users
                .Include(u => u.Bans)
                .FirstOrDefaultAsync(u => u.Username == loginRequest.Login || u.Mail == loginRequest.Login);

            var errorMesasge = "Incorrect login or password";

            if (user == null)
                return new AuthResult(user, false, errorMesasge);

            if (user.Bans.Any())
                return new AuthResult(user, false, "This account is banned");

            var hashedPassword = passwordHasher.HashPassword(user, "testp@ssw0rd");

            var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginRequest.Password);

            var success = verificationResult == PasswordVerificationResult.Success;

            return new AuthResult(user, success, success ? "" : errorMesasge);
        }
    }
}
