using System.Reflection.Metadata;
using System.Text;

namespace InGreed_API.Dtos.Results
{
    public class ResultBase
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public ResultBase(bool success, string errorMessage = "")
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"Result -> success: {Success}");
            if (!Success)
                result.Append($", error message: {ErrorMessage}");
            return result.ToString();
        }
    }
}
