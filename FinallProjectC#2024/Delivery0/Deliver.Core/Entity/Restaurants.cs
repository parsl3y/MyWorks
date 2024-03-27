using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Delivery.Core.Context
{
    public class Restaurants
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Image_Logo {  get; set; }
        public virtual ICollection<Reviews> Review { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

