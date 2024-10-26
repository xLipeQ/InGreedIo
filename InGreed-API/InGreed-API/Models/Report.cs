namespace InGreed_API.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int OpinionCreatorId { get; set; }
        public int ReporterId { get; set; }
        public int ProductId { get; set; }
        public string Reason {  get; set; }
    }
}
