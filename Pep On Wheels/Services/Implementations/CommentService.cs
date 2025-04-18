using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pep_On_Wheels.Data;
using Pep_On_Wheels.DTO.Comment;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Services
{
    public class CommentService : ICommentService
    {
        private readonly Pep_On_WheelsContext _context;
        private readonly IMapper _mapper;

        public CommentService(Pep_On_WheelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentReadDTO>> GetAllAsync()
        {
            var comments = await _context.Comments.ToListAsync();
            return _mapper.Map<IEnumerable<CommentReadDTO>>(comments);
        }

        public async Task<CommentReadDTO> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            return _mapper.Map<CommentReadDTO>(comment);
        }

        public async Task<CommentReadDTO> CreateAsync(CommentCreateDTO dto)
        {
            var comment = _mapper.Map<Comment>(dto);
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return _mapper.Map<CommentReadDTO>(comment);
        }

        public async Task<bool> UpdateAsync(int id, CommentUpdateDTO dto)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return false;

            _mapper.Map(dto, comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return false;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}