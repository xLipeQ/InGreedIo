namespace InGreed_API.Models
{
    public class Ban
    {
        public int Id { get; set; }
        public int UserId { get;set; }
        public string Reason { get; set; }

        public virtual User User { get; set; }
    }
}
