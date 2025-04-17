using System.Collections.Generic;
using System.Threading.Tasks;
using Pep_On_Wheels.DTO.Order;

namespace Pep_On_Wheels.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDTO>> GetAllAsync();
        Task<OrderReadDTO> GetByIdAsync(int id);
        Task<OrderReadDTO> CreateAsync(OrderCreateDTO dto);
        Task<bool> UpdateAsync(int id, OrderUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
