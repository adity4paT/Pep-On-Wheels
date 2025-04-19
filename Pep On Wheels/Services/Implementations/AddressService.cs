using Pep_On_Wheels.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pep_On_Wheels.DTO.Address;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Services
{
    public class AddressService : IAddressService
    {
        private readonly Pep_On_WheelsContext _context;
        private readonly IMapper _mapper;

        public AddressService(Pep_On_WheelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AddressReadDTO>> GetAllAsync()
        {
            var addresses = await _context.Addresses.ToListAsync();
            return _mapper.Map<IEnumerable<AddressReadDTO>>(addresses);
        }

        public async Task<AddressReadDTO> GetByIdAsync(int id)  
        {
            var address = await _context.Addresses.FindAsync(id);
            return _mapper.Map<AddressReadDTO>(address);
        }

        public async Task<AddressReadDTO> CreateAsync(AddressCreateDTO dto)
        {
            var address = _mapper.Map<Address>(dto);
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return _mapper.Map<AddressReadDTO>(address);
        }

        public async Task<bool> UpdateAsync(int id, AddressUpdateDTO dto)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null) return false;

            _mapper.Map(dto, address);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null) return false;

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}