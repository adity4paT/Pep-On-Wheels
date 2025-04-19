using Microsoft.AspNetCore.Mvc;
using Pep_On_Wheels.DTO.Address;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressReadDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressReadDTO>> GetById(int id)
        {
            var address = await _service.GetByIdAsync(id);
            return address != null ? Ok(address) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<AddressReadDTO>> Create(AddressCreateDTO dto)
        {
            var address = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = address.Id }, address);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddressUpdateDTO dto)
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
