using Azure;
using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Responses;
using InGreed_API.Dtos.Results;
using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InGreed_API.Services.LogService
{
    public class LogService : ILogService
    {
        private readonly string logDirectory = "Logs";

        private string GetLogFileName(DateTime dateTime)
            => $"{dateTime.ToString("yyyy-MM-dd")}.log";

        private string GetLogFilePath(DateTime dateTime)
        {
            string year = dateTime.ToString("yyyy");
            string month = dateTime.ToString("MM");
            string date = dateTime.ToString("yyyy-MM-dd");
            string logDirectory = Path.Combine("Logs", year, month);

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            return Path.Combine(logDirectory, GetLogFileName(dateTime));
        }

        public void Log(string message)
        {
            string logFilePath = GetLogFilePath(DateTime.Now);
            string logEntry = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {message}";

            lock (this)
            {
                if (!File.Exists(logFilePath))
                {
                    using (File.Create(logFilePath)) { }
                }
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine, Encoding.UTF8);
            }
        }

        public void Log(string message, ResultBase resultsBase)
        {
            Log($"{message}. {resultsBase}");
        }

        public LogResult GetLogFile(LogRequest logRequest)
        {
            string logFilePath = GetLogFilePath(logRequest.Date);

            if (!File.Exists(logFilePath))
                return new LogResult(false, "File not found", null);

            var logResponse = new LogResponse()
            {
                FileName = GetLogFileName(logRequest.Date),
                FileContent = File.ReadAllBytes(logFilePath),
                ContentType = "text/plain"
            };

            return new LogResult(true, "", logResponse);
        }
    }
}
