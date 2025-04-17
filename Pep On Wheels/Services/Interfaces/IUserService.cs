using System.Collections.Generic;
using System.Threading.Tasks;
using Pep_On_Wheels.DTO.Address;
using Pep_On_Wheels.DTO.User;

namespace Pep_On_Wheels.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDTO>> GetAllAsync();
        Task<UserReadDTO> GetByIdAsync(int id);
        Task<UserReadDTO> CreateAsync(UserCreateDTO dto);
        Task<UserReadDTO> UpdateAsync(int id, UserUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
