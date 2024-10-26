namespace InGreed_API.Dtos.Responses
{
    public class LogResponse
    {
        public byte[] FileContent { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
