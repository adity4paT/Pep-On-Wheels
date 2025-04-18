using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pep_On_Wheels.Data;
using Pep_On_Wheels.DTO.ProductImage;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly Pep_On_WheelsContext _context;
        private readonly IMapper _mapper;

        public ProductImageService(Pep_On_WheelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductImageReadDTO>> GetAllAsync()
        {
            var productImages = await _context.ProductImages.ToListAsync();
            return _mapper.Map<IEnumerable<ProductImageReadDTO>>(productImages);
        }

        public async Task<ProductImageReadDTO> GetByIdAsync(int id)
        {
            var productImage = await _context.ProductImages.FindAsync(id);
            return _mapper.Map<ProductImageReadDTO>(productImage);
        }

        public async Task<ProductImageReadDTO> CreateAsync(ProductImageCreateDTO dto)
        {
            var productImage = _mapper.Map<ProductImage>(dto);
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductImageReadDTO>(productImage);
        }

        public async Task<bool> UpdateAsync(int id, ProductImageUpdateDTO dto)
        {
            var productImage = await _context.ProductImages.FindAsync(id);
            if (productImage == null) return false;

            _mapper.Map(dto, productImage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var productImage = await _context.ProductImages.FindAsync(id);
            if (productImage == null) return false;

            _context.ProductImages.Remove(productImage);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}