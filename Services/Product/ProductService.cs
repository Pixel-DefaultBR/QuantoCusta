using QuantoCusta.Database.Repository.Product;
using QuantoCusta.Models;
using QuantoCusta.Services.Product;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task AddProductAsync(ProductModel product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Nome do produto é obrigatório.");

        if (product.Price < 0)
            throw new ArgumentException("Preço não pode ser negativo.");

        var existingProducts = await _productRepository.GetProductsAsync();
        if (existingProducts.Any(p => p.Name.ToLower() == product.Name.ToLower()))
            throw new InvalidOperationException("Já existe um produto com esse nome.");

        await _productRepository.AddProductAsync(product);
    }

    public async Task CommitAsync()
    {
        await _productRepository.CommitAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        if (product == null)
            throw new InvalidOperationException("Produto não encontrado para exclusão.");

        await _productRepository.DeleteProductAsync(id);
    }

    public async Task<ProductModel?> GetProductByIdAsync(int id)
    {
        return await _productRepository.GetProductByIdAsync(id);
    }

    public async Task<IEnumerable<ProductModel>> GetProductsAsync()
    {
        return await _productRepository.GetProductsAsync();
    }

    public async Task UpdateProductAsync(int id, ProductModel product)
    {
        var existing = await _productRepository.GetProductByIdAsync(id);
        if (existing == null)
            throw new InvalidOperationException("Produto não encontrado.");

        if (product.Price < 0)
            throw new ArgumentException("Preço não pode ser negativo.");

        await _productRepository.UpdateProductAsync(id, product);
    }
}
