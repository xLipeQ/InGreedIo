using InGreed_API.Controllers;
using InGreed_API.DataContext;
using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Responses;
using InGreed_API.Dtos.Results;
using InGreed_API.Models;
using InGreed_API.Services.AuthService;
using InGreed_API.Services.JwtService;
using InGreed_API.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Moq.EntityFrameworkCore;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InGreed_Api_Tests.ControllerTests
{
    public class LoginControllerTests
    {
        private Mock<IUserService> userServiceMock;

        public LoginControllerTests()
        {
            userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async Task Login_ValidCredentials_OkStatusCodeWithTokenReturned()
        {
            // Arrange
            var loginRequest = new LoginRequest("login", "password");
            var token = "token";
            var loginResult = new LoginResult(token, true);

            userServiceMock.Setup(u => u.Login(loginRequest)).ReturnsAsync(loginResult);

            var controller = new LoginController(userServiceMock.Object);

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<LoginResponse>(okResult.Value);
            Assert.Equal(token, returnValue.JwtToken);
        }

        [Fact]
        public async Task Login_InvalidCredentials_UnauthorizedStatusCodeReturned()
        {
            // Arrange
            var loginRequest = new LoginRequest("login", "password");
            var loginResult = new LoginResult("", false);

            userServiceMock.Setup(u => u.Login(loginRequest)).ReturnsAsync(loginResult);

            var controller = new LoginController(userServiceMock.Object);

            // Act
            var result = await controller.Login(loginRequest);
            
            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result);
        }
    }
}
