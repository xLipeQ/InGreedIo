using InGreed_API.Controllers;
using InGreed_API.Dtos.Responses;
using InGreed_API.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InGreed_API.Dtos.Requests;
using InGreed_API.Enums;
using InGreed_API.Dtos.Results;

namespace InGreed_Api_Tests.ControllerTests
{
    public class RegisterControllerTests
    {
        private Mock<IUserService> userServiceMock;

        public RegisterControllerTests()
        {
            userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async Task Register_NotExistingUser_OkStatusCodeWithTokenReturned()
        {
            // Arrange
            var registrationRequest = new RegistrationRequest("username", "mail", "password", UserRoleEnum.Client);
            var token = "token";
            var registrationResult = new LoginResult(token, true);

            userServiceMock.Setup(u => u.Register(registrationRequest)).ReturnsAsync(registrationResult);

            var controller = new RegistrationController(userServiceMock.Object);

            // Act
            var result = await controller.Register(registrationRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<LoginResponse>(okResult.Value);
            Assert.Equal(token, returnValue.JwtToken);
        }

        [Fact]
        public async Task Register_ExistingUser_UnauthorizedStatusCodeReturned()
        {
            // Arrange
            var registrationRequest = new RegistrationRequest("username", "mail", "password", UserRoleEnum.Client);
            var registrationResult = new LoginResult("", false);

            userServiceMock.Setup(u => u.Register(registrationRequest)).ReturnsAsync(registrationResult);

            var controller = new RegistrationController(userServiceMock.Object);

            // Act
            var result = await controller.Register(registrationRequest);

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result);
        }
    }
}
