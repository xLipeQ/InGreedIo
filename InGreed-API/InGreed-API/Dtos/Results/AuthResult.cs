using InGreed_API.Models;

namespace InGreed_API.Dtos.Results
{
    public class AuthResult : ResultBase
    {
        public User User { get; set; }

        public AuthResult(User user, bool success, string errorMessage = "") : base(success, errorMessage)
        {
            User = user;
        }
    }
}
