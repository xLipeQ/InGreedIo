using FluentAssertions;
using InGreed_API.DataContext;
using InGreed_API.Dtos;
using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Results;
using InGreed_API.Enums;
using InGreed_API.Hubs;
using InGreed_API.Models;
using InGreed_API.Services.AuthService;
using InGreed_API.Services.JwtService;
using InGreed_API.Services.LogService;
using InGreed_API.Services.UserService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.EntityFrameworkCore;

namespace InGreed_Api_Tests.ServiceTests
{
    public class UserServiceTests
    {
        private Mock<IAuthService> authServiceMock;
        private Mock<IJwtService> jwtServiceMock;
        private Mock<InGreedDataContext> dbContextMock;
        private Mock<IPasswordHasher<User>> passwordHasher;
        private Mock<IHubContext<SignalrHub>> hub;
        private Mock<IConfiguration> configuration;
        private Mock<ILogService> logServiceMock;

        public UserServiceTests()
        {
            authServiceMock = new Mock<IAuthService>();
            jwtServiceMock = new Mock<IJwtService>();
            dbContextMock = new Mock<InGreedDataContext>();
            passwordHasher = new Mock<IPasswordHasher<User>>();
            hub = new Mock<IHubContext<SignalrHub>>();
            configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x[It.IsAny<string>()]).Returns("");
            logServiceMock = new Mock<ILogService>();
        }

        [Fact]
        public async Task Login_ValidCredentials_TokenReturned()
        {
            // Arrange
            var loginRequest = new LoginRequest("login", "password");
            var user = new User();
            var authResult = new AuthResult(user, true);
            var token = "token";

            authServiceMock.Setup(x => x.AuthenticateUserAsyncUserAsync(loginRequest)).ReturnsAsync(authResult);
            jwtServiceMock.Setup(x => x.GenerateToken(user)).Returns(token);

            var userService = new UserService(authServiceMock.Object, jwtServiceMock.Object, dbContextMock.Object, passwordHasher.Object, hub.Object, configuration.Object, logServiceMock.Object);

            // Act
            var result = await userService.Login(loginRequest);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(token, result.JwtToken);
        }

        [Fact]
        public async Task Login_InvalidCredentials_TokenNotReturned()
        {
            // Arrange
            var loginRequest = new LoginRequest("login", "password");
            var authResult = new AuthResult(new User(), false);

            authServiceMock.Setup(x => x.AuthenticateUserAsyncUserAsync(loginRequest)).ReturnsAsync(authResult);

            var userService = new UserService(authServiceMock.Object, jwtServiceMock.Object, dbContextMock.Object, passwordHasher.Object, hub.Object, configuration.Object, logServiceMock.Object);

            // Act
            var result = await userService.Login(loginRequest);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("", result.JwtToken);
        }

        [Theory]
        [InlineData("testuser", "mail")]
        [InlineData("username", "testuser@gmail.com")]

        public async Task Register_ExistingUser_TokenNotReturned(string username, string mail)
        {
            // Arrange
            var errorMessage = "User already exists";
            var registerRequest = new RegistrationRequest(username, mail, "password", UserRoleEnum.Client);
            dbContextMock.Setup(c => c.Users).ReturnsDbSet(new List<User> { new User
            {
                Username = username,
                Mail = mail
            } 
            });
            dbContextMock.Setup(c => c.Users.AddAsync(It.IsAny<User>(), default)).Verifiable();
            dbContextMock.Setup(c => c.SaveChangesAsync(default)).Verifiable();

            var userService = new UserService(authServiceMock.Object, jwtServiceMock.Object, dbContextMock.Object, passwordHasher.Object, hub.Object, configuration.Object, logServiceMock.Object);

            // Act
            var result = await userService.Register(registerRequest);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("", result.JwtToken);
            Assert.Equal(errorMessage, result.ErrorMessage);
            dbContextMock.Verify(c => c.Users.AddAsync(It.IsAny<User>(), default), Times.Never());
            dbContextMock.Verify(c => c.SaveChangesAsync(default), Times.Never());
        }

        [Fact]
        public async Task Register_NotExistingUser_TokenReturned()
        {
            // Arrange
            var registerRequest = new RegistrationRequest("username", "mail", "password", UserRoleEnum.Client);
            var token = "token";
            List<User> users = new List<User>();

            jwtServiceMock.Setup(x => x.GenerateToken(It.IsAny<User>())).Returns(token);

            dbContextMock.Setup(c => c.Users).ReturnsDbSet(users);
            dbContextMock.Setup(c => c.Users.AddAsync(It.IsAny<User>(), default))
                .Callback((User user, CancellationToken cancellation) => users.Add(user));
            dbContextMock.Setup(c => c.SaveChangesAsync(default)).Verifiable();

            var userService = new UserService(authServiceMock.Object, jwtServiceMock.Object, dbContextMock.Object, passwordHasher.Object, hub.Object, configuration.Object, logServiceMock.Object);

            // Act
            var result = await userService.Register(registerRequest);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(token, result.JwtToken);

            var user = users.Single();
            user.Username.Should().Be("username");
            user.Mail.Should().Be("mail");
            user.Role.Should().Be(UserRoleEnum.Client);
        }
    }
}
