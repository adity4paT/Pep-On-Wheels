using Microsoft.AspNetCore.Mvc;
using Pep_On_Wheels.DTO.Product;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDTO>>> GetAllProducts()
        {
            return Ok(await _service.GetAllProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDTO>> GetProductById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ProductReadDTO>> CreateProduct(ProductCreateDTO dto)
        {
            var product = await _service.CreateProductAsync(dto);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDTO dto)
        {
            return await _service.UpdateProductAsync(id, dto) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return await _service.DeleteProductAsync(id) ? NoContent() : NotFound();
        }
    }
}
