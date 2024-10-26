namespace InGreed_API.Models
{
    public class FavouriteProduct
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
