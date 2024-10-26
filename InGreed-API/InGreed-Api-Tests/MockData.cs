using InGreed_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace InGreed_Api_Tests
{
    public static class MockData
    {
        public static User GetUser()
        {
            var passwordHasher = new PasswordHasher<User>();
            var user = new User() { Id = 1, Username = "testuser", Mail = "testuser@gmail.com", Bans = new() };
            var hashedPassword = passwordHasher.HashPassword(user, "testp@ssw0rd");
            user.PasswordHash = hashedPassword;

            return user;
        }

    }
}
