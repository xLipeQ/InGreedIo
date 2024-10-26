using InGreed_API.DataContext;
using InGreed_API.Models;
using InGreed_API.Services.AuthService;
using InGreed_API.Services.JwtService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InGreed_Api_Tests.ServiceTests
{
    public class JwtServiceTests
    {
        [Fact]
        public void GenerateToken_CorrectUser_ValidTokenIsGenerated()
        {
            // Arrange
            var configurationService = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var jwtService = new JwtService(configurationService);
            var user = MockData.GetUser();

            // Act
            var token = jwtService.GenerateToken(user); 
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            // Assert
            Assert.Equal(user.Id.ToString(), jsonToken?.Claims.First(c => c.Type == "Id").Value);
            Assert.Equal(user.Username, jsonToken?.Claims.First(c => c.Type == "Username").Value);
            Assert.Equal(user.Mail, jsonToken?.Claims.First(c => c.Type == "Mail").Value);
            Assert.Equal(user.Role.ToString(), jsonToken?.Claims.First(c => c.Type == ClaimTypes.Role).Value);
        }
    }
}
