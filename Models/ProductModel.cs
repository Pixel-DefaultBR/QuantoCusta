using System.ComponentModel.DataAnnotations;

namespace QuantoCusta.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do produto é obrigatorio.")]
        [StringLength(100, ErrorMessage = "O nome do produto deve ter no máximo 100 caracteres.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Descrição do produto é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição do produto deve ter no máximo 500 caracteres.")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Preço do produto é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel? Category { get; set; } = null;
    }
}
