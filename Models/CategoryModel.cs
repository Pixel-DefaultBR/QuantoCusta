namespace QuantoCusta.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
