namespace InGreed_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProducentId { get; set; }
        public string Description { get; set; }
        public virtual List<ProductCategory> ProductCategory { get; set; }
        public virtual List<ProductIngredient> ProductIngredients { get; set; }
        public virtual Promotion Promotion { get; set; }
        public virtual User Producent { get; set; }
        public virtual List<Opinion> Opinions { get; set; }
        public virtual List<FavouriteProduct> FavouriteProducts { get; set; }
        public virtual ProductImage Image { get; set; }
    }
}
