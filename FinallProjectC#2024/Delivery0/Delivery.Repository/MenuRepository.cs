using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Delivery.Core.Context;

namespace Delivery.Repository
{
    public class MenuRepository
    {
        private readonly DeliveryContextDB _context;

        public MenuRepository(DeliveryContextDB context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Menu>> GetMenusByRestaurantIdAsync(int restaurantId)
        {
            return await _context.Menu
                .Include(m => m.Restaurant)
                .Include(m => m.Dish)
                .Where(m => m.RestaurantId == restaurantId)
                .ToListAsync();
        }
        public async Task<Menu> GetMenuByRestaurantAndDishAsync(int restaurantId, int dishId)
        {
            return await _context.Menu
                .FirstOrDefaultAsync(m => m.RestaurantId == restaurantId && m.DishId == dishId);
        }
        public async Task<List<Menu>> GetMenusAsync()
        {
            return await _context.Menu
                .Include(m => m.Restaurant)
                .Include(m => m.Dish)
                .ToListAsync();
        }
        public async Task AddMenuAsync(Menu menu)
        {
            _context.Menu.Add(menu);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteMenuAsync(Menu menu)
        {
            _context.Menu.Remove(menu);
            await _context.SaveChangesAsync();
        }
        public async Task<Restaurants> GetRestaurantByIdAsync(int restaurantId)
        {
            return await _context.Restaurants
                .FirstOrDefaultAsync(r => r.Id == restaurantId);
        }
    }
}
