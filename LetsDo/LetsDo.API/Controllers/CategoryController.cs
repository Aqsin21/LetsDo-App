using LetsDo.API.Dtos.Category;
using LetsDo.BLL.Services.Abstract;
using LetsDo.BLL.Services.Concrete;
using LetsDo.DAL.DataContext.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LetsDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericService<Category> _categoryService;

        public CategoryController(IGenericService<Category> categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var category = new Category
            {
                Name = dto.Name,
                Icon = dto.Icon
               
            };
            await _categoryService.CreateAsync(category);
            return Ok(category);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();
            category.Name = dto.Name;
            category.Icon = dto.Icon;
            await _categoryService.UpdateAsync(category);
            return Ok(category);


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var exists = await _categoryService.AnyAsync(e => e.Id == id);
            if (!exists) return NotFound();

            await _categoryService.DeleteAsync(id);
            return Ok("Category Deleted");
        }
    }
}
