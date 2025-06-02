using Microsoft.EntityFrameworkCore;
using QuantoCusta.Models;

namespace QuantoCusta.Database.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddProductAsync(ProductModel product)
        {
            var newProduct = new ProductModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Category = product.Category
            };

            await _context.Products.AddAsync(newProduct);
        }
        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products.Select(p => new ProductModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
            });
        }
        public async Task<ProductModel?> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return product;
            }

            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };
        }
        public async Task UpdateProductAsync(int id, ProductModel product)
        {
            var existingProduct = await _context.Products.FindAsync(id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.CategoryId = product.CategoryId;

                _context.Products.Update(existingProduct);
            }
        }
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
