namespace InGreed_API.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Icon { get; set; }
        public List<ProductIngredient> ProductIngredients { get; set; }
        public List<Preference> Preferenes { get; set; }
    }
}
