namespace InGreed_API.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public virtual Product Product { get; set; }
    }
}
