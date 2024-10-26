using InGreed_API.Models;

namespace InGreed_API.Services.JwtService
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
