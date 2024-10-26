namespace InGreed_API.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public byte[] Image { get; set; }
        public virtual Product Product { get; set; }
    }
}
