using System.Linq;
using Microsoft.EntityFrameworkCore;
using Delivery.Core.Context;

namespace Delivery.Repository
{
    public class DishRepository
    {
        private readonly DeliveryContextDB _context;
        public DishRepository(DeliveryContextDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dish>> GetAllDishesAsync()
        {
            return await _context.Dishes.ToListAsync();
        }

        public async Task AddDishAsync(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDishAsync(Dish dish)
        {
            _context.Entry(dish).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
