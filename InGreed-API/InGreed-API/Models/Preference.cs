using InGreed_API.Enums;

namespace InGreed_API.Models
{
    public class Preference
    {
        public int UserId { get; set; }
        public int IngredientId { get; set; }
        public PreferenceEnum PreferenceType { get; set; }
        public User User { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
