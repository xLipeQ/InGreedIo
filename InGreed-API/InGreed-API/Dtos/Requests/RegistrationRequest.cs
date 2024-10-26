using InGreed_API.Enums;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InGreed_API.Dtos.Requests
{
    public class RegistrationRequest
    {
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }

        public RegistrationRequest(string username, string mail, string password, UserRoleEnum role)
        {
            Username = username;
            Mail = mail;
            Password = password;
            Role = role;
        }
    }
}
