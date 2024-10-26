using InGreed_API.Dtos.Responses;

namespace InGreed_API.Dtos.Results
{
    public class LogResult : ResultBase
    {
        public LogResponse Response { get; set; }

        public LogResult(bool success, string errorMessage = "", LogResponse logResponse = null) : base(success, errorMessage)
        {
            Response = logResponse;
        }
    }
}
