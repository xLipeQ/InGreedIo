namespace InGreed_API.Dtos.Responses
{
    public class ReportResponse
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }
        public int OpinionCreatorId { get; set; }
        public int ProductId {  get; set; }
        public string Reason { get; set; }
    }
}
