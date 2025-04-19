using Microsoft.AspNetCore.Mvc;
using Pep_On_Wheels.DTO.Category;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryReadDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryReadDTO>> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);
            return category != null ? Ok(category) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryReadDTO>> Create(CategoryCreateDTO dto)
        {
            var category = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
            //                 Action to generate URL  │   Route parameters  │ Response body

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryUpdateDTO dto)
        {
            return await _service.UpdateAsync(id, dto) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}
