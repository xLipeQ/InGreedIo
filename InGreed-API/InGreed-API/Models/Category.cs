namespace InGreed_API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual List<ProductCategory> ProductCategory { get; set; }
    }
}
