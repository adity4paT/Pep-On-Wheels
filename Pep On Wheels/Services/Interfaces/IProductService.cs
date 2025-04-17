using System.Collections.Generic;
using System.Threading.Tasks;
using Pep_On_Wheels.DTO.Product;

namespace Pep_On_Wheels.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDTO>> GetAllProductsAsync();
        Task<ProductReadDTO> GetProductByIdAsync(int id);
        Task<ProductReadDTO> CreateProductAsync(ProductCreateDTO productDto);
        Task<bool> UpdateProductAsync(int id, ProductUpdateDTO productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
