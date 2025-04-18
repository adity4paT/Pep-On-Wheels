using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pep_On_Wheels.Data;
using Pep_On_Wheels.DTO.Order;
using Pep_On_Wheels.Models;
using Pep_On_Wheels.Services.Interfaces;

namespace Pep_On_Wheels.Services
{
    public class OrderService : IOrderService
    {
        private readonly Pep_On_WheelsContext _context;
        private readonly IMapper _mapper;

        public OrderService(Pep_On_WheelsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderReadDTO>> GetAllAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();
            return _mapper.Map<IEnumerable<OrderReadDTO>>(orders);
        }

        public async Task<OrderReadDTO> GetByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);
            return _mapper.Map<OrderReadDTO>(order);
        }

        public async Task<OrderReadDTO> CreateAsync(OrderCreateDTO dto)
        {
            var order = _mapper.Map<Order>(dto);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderReadDTO>(order);
        }

        public async Task<bool> UpdateAsync(int id, OrderUpdateDTO dto)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            _mapper.Map(dto, order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}