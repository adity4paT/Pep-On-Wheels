using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pep_On_Wheels.Data;
using Pep_On_Wheels.DTO.Product;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Services
{
    public class ProductService : IProductService
    {
        private readonly Pep_On_WheelsContext _context;
        private readonly IMapper _mapper;

        public ProductService(Pep_On_WheelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductReadDTO>> GetAllProductsAsync()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<ProductReadDTO>>(products);
        }

        public async Task<ProductReadDTO> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return _mapper.Map<ProductReadDTO>(product);
        }

        public async Task<ProductReadDTO> CreateProductAsync(ProductCreateDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductReadDTO>(product);
        }

        public async Task<bool> UpdateProductAsync(int id, ProductUpdateDTO dto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _mapper.Map(dto, product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}