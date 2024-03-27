using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Delivery.Core.Context;

namespace Delivery.Repository
{
    public class ReviewsRepository
    {
        private readonly DeliveryContextDB _context;

        public ReviewsRepository(DeliveryContextDB context)
        {
            _context = context;
        }
        public async Task AddReviewAsync(Reviews review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> HasUserReviewedAsync(int userId, int restaurantId)
        {
            return await _context.Reviews.AnyAsync(r => r.UserId == userId && r.RestaurantsId == restaurantId);
        }
    }
}
