using QuantoCusta.DTOS;
using QuantoCusta.Models;

namespace QuantoCusta.Database.Repository.Category
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(CategoryModel category);
        Task UpdateCategoryAsync(int id, CategoryModel category);
        Task DeleteCategoryAsync(int id);
        Task<IEnumerable<CategoryModel?>> GetAllCategoriesAsync();
        Task<CategoryModel?> GetCategoryByIdAsync(int id);
        Task CommitAsync();
    }
}
