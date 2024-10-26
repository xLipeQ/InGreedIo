using InGreed_API.Dtos.Requests;
using InGreed_API.Models;

namespace InGreed_API.Dtos.Responses.ProductResponse
{
    public class ProductRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPromoted { get; set; }
        public bool IsFavourite { get; set; }
        public double AverageOpinion { get; set; }
        public int NumberOfOpinions { get; set; }

        public ProductRow(Product p, bool isPromoted, int? userId)
        {
            Id = p.Id;
            Name = p.Name;
            Description = p.Description;
            IsPromoted = isPromoted;
            IsFavourite = userId == null ? false : p.FavouriteProducts.Any(fp => fp.UserId == userId);
            NumberOfOpinions = p.Opinions.Count();
            AverageOpinion = NumberOfOpinions == 0 ? 0 : p.Opinions.Average(o => o.Rating);
        }
    }
}
