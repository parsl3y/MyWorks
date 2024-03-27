using System.Linq;
using Microsoft.EntityFrameworkCore;
using Delivery.Core.Context;

namespace Delivery.Repository
{
    public class RestaurantsRepository
    {
        private readonly DeliveryContextDB _context;

        public RestaurantsRepository(DeliveryContextDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurants>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

    }
}
