using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Delivery.Core.Context
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RestaurantId { get; set; }
        public int DishId { get; set; }
        public virtual Restaurants Restaurant { get; set; }
        public virtual Dish Dish { get; set; }

        public override string ToString()
        {
            return $"{Restaurant}|{Dish}";
        }
    }
}
