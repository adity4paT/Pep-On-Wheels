using Microsoft.AspNetCore.Mvc;
using Pep_On_Wheels.DTO.Cart;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItemReadDTO>>> GetCartItems()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartItemReadDTO>> GetCartItem(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item != null ? Ok(item) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CartItemReadDTO>> AddToCart(CartItemReadDTO dto)
        {
            var item = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetCartItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, CartUpdateDTO dto)
        {
            return await _service.UpdateAsync(id, dto) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            return await _service.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}
