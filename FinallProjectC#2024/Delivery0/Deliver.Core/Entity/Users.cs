using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using Delivery.Core.Entity;

namespace Delivery.Core.Context
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password {  get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }
        public int RoleId {  get; set; }
        public Role Role { get; set; }
        public virtual ICollection<Reviews> Review { get; set; }
        public override string ToString()
        {
            return $"{Name};{Phone}";
        }

    }
}
 