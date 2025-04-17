using System.Collections.Generic;
using System.Threading.Tasks;
using Pep_On_Wheels.DTO.Cart;

namespace Pep_On_Wheels.Services.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<CartItemReadDTO>> GetAllAsync();
        Task<CartItemReadDTO> GetByIdAsync(int id);
        Task<CartItemReadDTO> CreateAsync(CartItemReadDTO dto);
        Task<bool> UpdateAsync(int id, CartUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
