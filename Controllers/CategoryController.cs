using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuantoCusta.DTOS;
using QuantoCusta.Models;
using QuantoCusta.Services.Category;

namespace QuantoCusta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto category)
        {
            var model = _mapper.Map<CategoryModel>(category);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _categoryService.AddCategoryAsync(model);
            await _categoryService.CommitAsync();

            var response = _mapper.Map<CategoryResponseDto>(model);

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = _mapper.Map<CategoryModel>(category);

            var existing = await _categoryService.GetCategoryByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _categoryService.UpdateCategoryAsync(id, model);
            await _categoryService.CommitAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            await _categoryService.DeleteCategoryAsync(id);
            await _categoryService.CommitAsync();

            return NoContent();
        }
    }
}
