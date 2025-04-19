using Microsoft.AspNetCore.Mvc;
using Pep_On_Wheels.DTO.User;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> Create(UserCreateDTO dto)
        {
            var user = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserReadDTO>> Update(int id, UserUpdateDTO dto)
        {
            var user = await _service.UpdateAsync(id, dto);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}
