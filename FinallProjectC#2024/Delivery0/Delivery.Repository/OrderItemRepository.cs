using Delivery.Core.Context;
using Delivery.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Core.Repository
{
    public class OrderItemRepository
    {
        private readonly DeliveryContextDB _context;

        public OrderItemRepository(DeliveryContextDB context)
        {
            _context = context;
        }
        public async Task<List<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItem
                .Include(orderItem => orderItem.Orders)
                    .ThenInclude(order => order.status)
                .ToListAsync();
        }
        public async Task AddAsync(OrderItem orderItem)
        {
            _context.OrderItem.Add(orderItem);
            await _context.SaveChangesAsync();
        }
        public async Task<List<OrderItem>> GetUserOrdersAsync(int userId)
        {
            return await _context.OrderItem
                .Where(item => item.UserId == userId)
                .ToListAsync();
        }
        public async Task<List<OrderItem>> GetOrderByStatus()
        {
            return _context.OrderItem.Where(y => y.Orders.status.Id != 3).ToList();
        }

    }
}
