using Microsoft.AspNetCore.Mvc;
using Pep_On_Wheels.DTO.ProductImage;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _service;

        public ProductImageController(IProductImageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductImageReadDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductImageReadDTO>> GetById(int id)
        {
            var image = await _service.GetByIdAsync(id);
            return image != null ? Ok(image) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ProductImageReadDTO>> Create(ProductImageCreateDTO dto)
        {
            var image = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = image.Id }, image);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductImageUpdateDTO dto)
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
