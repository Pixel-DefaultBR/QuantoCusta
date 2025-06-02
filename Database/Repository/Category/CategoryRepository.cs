using Microsoft.EntityFrameworkCore;
using QuantoCusta.Models;

namespace QuantoCusta.Database.Repository.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(CategoryModel category)
        {
            var categories = await _context.Categories.AnyAsync();

            if (!categories)
            {
                await CreateDefaultCategory();
                await _context.SaveChangesAsync();
            }

            var newCategory = new CategoryModel
            {
                Name = category.Name,
                Description = category.Description,
            };

            await _context.Categories.AddAsync(newCategory);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                var defaulCategory = await CreateDefaultCategory();

                if (defaulCategory == null)
                {
                    defaulCategory = new CategoryModel { Name = "Sem Categoria", Description = "Categoria padrão para produtos sem categoria." };
                    await _context.Categories.AddAsync(defaulCategory);
                }

                foreach (var product in category.Products)
                {
                    product.CategoryId = defaulCategory.Id;
                }

                _context.Categories.Remove(category);
            }
        }

        public async Task<IEnumerable<CategoryModel?>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.Include(c => c.Products).ToListAsync();
            
            return categories;
        }

        public async Task<CategoryModel?> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);

            if ( category == null) 
            {
                    return category;
            }
            
            return category;
        }

        public async Task UpdateCategoryAsync(int id, CategoryModel category)
        {
            var existingCategory = await _context.Categories.FindAsync(id);

            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
            }
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        private async Task<CategoryModel> CreateDefaultCategory()
        {
            var defaulCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Name == "Sem Categoria");

            if (defaulCategory == null)
            {
                defaulCategory = new CategoryModel { Name = "Sem Categoria", Description = "Categoria padrão para produtos sem categoria." };
                await _context.Categories.AddAsync(defaulCategory);

                return defaulCategory;
            }

            return defaulCategory;
        } 
    }
}
