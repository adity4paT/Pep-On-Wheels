using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pep_On_Wheels.Data;
using Pep_On_Wheels.DTO.Category;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly Pep_On_WheelsContext _context;
        private readonly IMapper _mapper;

        public CategoryService(Pep_On_WheelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryReadDTO>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return _mapper.Map<IEnumerable<CategoryReadDTO>>(categories);
        }

        public async Task<CategoryReadDTO> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return _mapper.Map<CategoryReadDTO>(category);
        }

        public async Task<CategoryReadDTO> CreateAsync(CategoryCreateDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoryReadDTO>(category);
        }

        public async Task<bool> UpdateAsync(int id, CategoryUpdateDTO dto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _mapper.Map(dto, category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}