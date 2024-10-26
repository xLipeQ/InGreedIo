namespace InGreed_API.Dtos.Requests
{
    public record AddReportRequest
    {
        public int ProductId {  get; set; }
        public int OpinionCreatorId {  get; set; }
        public int ReporterId {  get; set; }
        public string Reason { get; set; }
    }
}
