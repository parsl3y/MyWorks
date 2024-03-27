using Delivery.Core.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Delivery.Core.Entity
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public int UserId { get; set; }
        public virtual Users User { get; set; }
        public int OrdersId {  get; set; }
        public Orders Orders { get; set; }
        public string NameDish { get; set; }
        public DateTime OrderDate { get; set; }
        public int DishPrice { get; set; }
        public string Address { get; set; }
        
    }
}
