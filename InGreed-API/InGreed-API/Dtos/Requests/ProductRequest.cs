namespace InGreed_API.Dtos.Requests
{
    public class ProductRequest
    {
        public int? Id { get; set; }
        public bool OnlyFavourite { get; set; }
        public int? Category { get; set; }
        public string SearchPhrase { get; set; }
        public List<int> Ingredients { get; set; }
        public int PageNumber { get; set; }
        public int NormalNumber { get; set; }
        public int PromotionNumber { get; set; }
    }
}
