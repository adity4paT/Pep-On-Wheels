using Microsoft.AspNetCore.Mvc;
using Pep_On_Wheels.DTO.Comment;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentReadDTO>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentReadDTO>> GetById(int id)
        {
            var comment = await _service.GetByIdAsync(id);
            return comment != null ? Ok(comment) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CommentReadDTO>> Create(CommentCreateDTO dto)
        {
            var comment = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CommentUpdateDTO dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}
