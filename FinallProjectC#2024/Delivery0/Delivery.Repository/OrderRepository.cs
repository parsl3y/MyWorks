using Microsoft.EntityFrameworkCore;
using Delivery.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delivery.Core.Entity;

namespace Delivery.Repository
{
    public class OrderRepository
    {
        private readonly DeliveryContextDB _context;

        public OrderRepository(DeliveryContextDB context)
        {
            _context = context;
        }

        public async Task<List<Orders>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task UpdateOrderAsync(Orders order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        }
}
