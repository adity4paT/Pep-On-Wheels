using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pep_On_Wheels.Data;
using Pep_On_Wheels.DTO.Cart;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Services
{
    public class CartService : ICartService
    {
        private readonly Pep_On_WheelsContext _context;
        private readonly IMapper _mapper;

        public CartService(Pep_On_WheelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CartItemReadDTO>> GetAllAsync()
        {
            var cartItems = await _context.CartItems.ToListAsync();
            return _mapper.Map<IEnumerable<CartItemReadDTO>>(cartItems);
        }

        public async Task<CartItemReadDTO> GetByIdAsync(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            return _mapper.Map<CartItemReadDTO>(cartItem);
        }

        public async Task<CartItemReadDTO> CreateAsync(CartItemReadDTO dto)
        {
            var cartItem = _mapper.Map<CartItem>(dto);
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return _mapper.Map<CartItemReadDTO>(cartItem);
        }

        public async Task<bool> UpdateAsync(int id, CartUpdateDTO dto)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null) return false;

            _mapper.Map(dto, cartItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null) return false;

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}