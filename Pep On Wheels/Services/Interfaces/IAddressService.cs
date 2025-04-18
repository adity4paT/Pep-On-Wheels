    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Pep_On_Wheels.DTO.Address;

    namespace Pep_On_Wheels.Services.Interfaces
    {
        public interface IAddressService 
        {
            Task<IEnumerable<AddressReadDTO>> GetAllAsync();
            Task<AddressReadDTO> GetByIdAsync(int id);
            Task<AddressReadDTO> CreateAsync(AddressCreateDTO dto);
            Task<bool> UpdateAsync(int id, AddressUpdateDTO dto);
            Task<bool> DeleteAsync(int id);
        }
    }
