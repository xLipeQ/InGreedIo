namespace InGreed_API.Dtos.Responses
{
    public class OpinionResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}
