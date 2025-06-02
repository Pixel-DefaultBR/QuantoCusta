using QuantoCusta.Database.Repository.Category;
using QuantoCusta.Models;

namespace QuantoCusta.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task AddCategoryAsync(CategoryModel category)
        {
            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task CommitAsync()
        {
            await _categoryRepository.CommitAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }

        public async Task<IEnumerable<CategoryModel?>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task<CategoryModel?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task UpdateCategoryAsync(int id, CategoryModel category)
        {
            await _categoryRepository.UpdateCategoryAsync(id, category);
        }
    }
}
