using Microsoft.AspNetCore.Mvc;
using Pep_On_Wheels.DTO.Order;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReadDTO>> GetById(int id)
        {
            var order = await _service.GetByIdAsync(id);
            return order != null ? Ok(order) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<OrderReadDTO>> Create(OrderCreateDTO dto)
        {
            var order = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderUpdateDTO dto)
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
