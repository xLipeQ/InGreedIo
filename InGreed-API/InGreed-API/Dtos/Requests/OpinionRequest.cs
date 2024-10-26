namespace InGreed_API.Dtos.Requests
{
    public class OpinionRequest
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
