using InGreed_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InGreed_API.Services.JwtService
{
    public class JwtService(IConfiguration config) : IJwtService
    {
        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", $"{user.Id}"),
                new Claim("Username", user.Username),
                new Claim("Mail", user.Mail),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var jwtSecretKey = config["SecretKeys:JwtSecretKey"] ?? "";
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: config["Audiences:api"],
                audience: config["Audiences:gui"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: signingCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
}
