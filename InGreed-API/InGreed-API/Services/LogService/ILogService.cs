using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Results;

namespace InGreed_API.Services.LogService
{
    public interface ILogService
    {
        public void Log(string message);
        public void Log(string message, ResultBase resultsBase);
        public LogResult GetLogFile(LogRequest logRequest);
    }
}
