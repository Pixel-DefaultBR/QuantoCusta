using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuantoCusta.Models;
using QuantoCusta.DTOS;
using QuantoCusta.Services.Product;

namespace QuantoCusta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAll()
        {
            var products = await _productService.GetProductsAsync();
            var result = _mapper.Map<IEnumerable<ProductResponseDto>>(products);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(_mapper.Map<ProductResponseDto>(product));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProductDto product)
        {
            var model = _mapper.Map<ProductModel>(product);

            await _productService.AddProductAsync(model);
            await _productService.CommitAsync();

            var response = _mapper.Map<ProductResponseDto>(model);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            var existing = await _productService.GetProductByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            await _productService.UpdateProductAsync(id, existing);
            await _productService.CommitAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            await _productService.CommitAsync();
            return NoContent();
        }
    }
}
