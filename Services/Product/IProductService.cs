using QuantoCusta.Models;

namespace QuantoCusta.Services.Product
{
    public interface IProductService
    {
        Task AddProductAsync(ProductModel product);
        Task<IEnumerable<ProductModel>> GetProductsAsync();
        Task<ProductModel?> GetProductByIdAsync(int id);
        Task UpdateProductAsync(int id, ProductModel product);
        Task DeleteProductAsync(int id);
        Task CommitAsync();
    }
}
