using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Core.Entity;

namespace Delivery.Core.Context
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public int StatusId { get; set; }
        public Status status { get; set; }

        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
