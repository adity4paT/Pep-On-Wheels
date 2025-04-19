using System.Collections.Generic;
using System.Threading.Tasks;
using Pep_On_Wheels.DTO.Category;

namespace Pep_On_Wheels.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadDTO>> GetAllAsync();
        Task<CategoryReadDTO> GetByIdAsync(int id);
        Task<CategoryReadDTO> CreateAsync(CategoryCreateDTO dto);
        Task<bool> UpdateAsync(int id, CategoryUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
