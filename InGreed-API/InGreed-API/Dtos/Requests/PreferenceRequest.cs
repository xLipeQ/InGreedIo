using InGreed_API.Enums;

namespace InGreed_API.Dtos.Requests
{
    public class PreferenceRequest
    {
        public int UserId { get; set; }
        public int IngredientId { get; set; }
        public PreferenceEnum? Type { get; set; }
    }

    public class MultiplePreferenceRequest
    {
        public int UserId { get; set; }
        public List<int> IngredientIds { get; set; }
    }
}
