using QuantoCusta.Models;

namespace QuantoCusta.Services.Category
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(CategoryModel category);
        Task UpdateCategoryAsync(int id, CategoryModel category);
        Task DeleteCategoryAsync(int id);
        Task<IEnumerable<CategoryModel?>> GetAllCategoriesAsync();
        Task<CategoryModel?> GetCategoryByIdAsync(int id);
        Task CommitAsync();
    }
}
