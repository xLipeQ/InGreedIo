namespace InGreed_API.Dtos.Responses
{
    public class LoginResponse
    {
        public string JwtToken { get; set; }

        public LoginResponse(string jwtToken)
        {
            JwtToken = jwtToken;
        }
    }
}
