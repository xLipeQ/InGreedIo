namespace InGreed_API.Dtos.Results
{
    public class LoginResult : ResultBase
    {
        public string JwtToken { get; set; }

        public LoginResult(string jwtToken, bool success, string errorMessage = "") : base(success, errorMessage)
        {
            JwtToken = jwtToken;
        }
    }
}
