using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Core.Context
{
    public class Reviews
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public int UserId {  get; set; }
        public virtual Users User { get; set; }
        public int RestaurantsId {  get; set; }
        public virtual Restaurants Restaurants { get; set; }
        public string TextReviews { get; set; }
        public int Rating { get; set; }

        public override string ToString()
        {
            return $"{TextReviews},{Rating}";
        }
    }
}
