using System.Collections.Generic;
using System.Threading.Tasks;
using Pep_On_Wheels.DTO.Comment;

namespace Pep_On_Wheels.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentReadDTO>> GetAllAsync();
        Task<CommentReadDTO> GetByIdAsync(int id);
        Task<CommentReadDTO> CreateAsync(CommentCreateDTO dto);
        Task<bool> UpdateAsync(int id, CommentUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
