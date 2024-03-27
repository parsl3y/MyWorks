using Delivery.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Core.Context
{
    public class DeliveryContextDB : DbContext
    {

        public DbSet<Users> Users { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Status> Statuss {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.;Database=Delivery; " +
                "Integrated Security=True;Encrypt=True;TrustServerCertificate=True\r\n";

            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
