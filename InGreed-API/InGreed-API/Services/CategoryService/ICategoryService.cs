using InGreed_API.Dtos.Responses;

namespace InGreed_API.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponse>> GetAllCategories();
        public Task<List<CategoryResponse>> GetAllMatchingCategories(string pattern);
    }
}
