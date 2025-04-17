using System.Collections.Generic;
using System.Threading.Tasks;
using Pep_On_Wheels.DTO.ProductImage;

namespace Pep_On_Wheels.Services.Interfaces
{
    public interface IProductImageService
    {
        Task<IEnumerable<ProductImageReadDTO>> GetAllAsync();
        Task<ProductImageReadDTO> GetByIdAsync(int id);
        Task<ProductImageReadDTO> CreateAsync(ProductImageCreateDTO dto);
        Task<bool> UpdateAsync(int id, ProductImageUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
