using InGreed_API.DataContext;
using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Results;
using InGreed_API.Models;
using InGreed_API.Services.AuthService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InGreed_Api_Tests.ServiceTests
{
    public class AuthServiceTests
    {
        private Mock<InGreedDataContext> dbContextMock;
        private User user;

        public AuthServiceTests()
        {
            dbContextMock = new Mock<InGreedDataContext>();
            user = MockData.GetUser();
        }

        [Fact]
        public async Task AuthenticateUserAsync_CorrectMailAndPassword_IsAuthenticated()
        {
            // Arrange
            dbContextMock.Setup(c => c.Users).ReturnsDbSet(new List<User> { user });


            var authService = new AuthService(dbContextMock.Object, new PasswordHasher<User>());

            var mail = "testuser@gmail.com";
            var loginRequest = new LoginRequest(mail, "testp@ssw0rd");
            
            // Act
            var result = await authService.AuthenticateUserAsyncUserAsync(loginRequest);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(mail, result.User.Mail);
        }

        [Fact]
        public async Task AuthenticateUserAsync_WrongPassword_IsNotAuthenticated()
        {
            // Arrange
            dbContextMock.Setup(c => c.Users).ReturnsDbSet(new List<User> { user });

            var authService = new AuthService(dbContextMock.Object, new PasswordHasher<User>());

            var username = "testuser";
            var loginRequest = new LoginRequest(username, "testpassword");
            var errorMessage = "Incorrect login or password";
            
            // Act
            var result = await authService.AuthenticateUserAsyncUserAsync(loginRequest);

            // Assert
            Assert.False(result.Success);
            Assert.Equal(errorMessage, result.ErrorMessage);
        }
    }
}
