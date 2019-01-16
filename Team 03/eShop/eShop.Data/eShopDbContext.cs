using eShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data
{
    public class eShopDbContext : DbContext
    {
        public eShopDbContext() : base("eShopConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }


        public DbSet<Cart> Cart { get; set; }

        public DbSet<CartItem> CartItem { get; set; }

        public DbSet<Error> Error { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<OrderNumber> OrderNumber { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Artist> Artist { get; set; }

        public DbSet<Rating> Rating { get; set; }

        public DbSet<User> User { get; set; }


        public static eShopDbContext Create()
        {
            return new eShopDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {

        }
    }
}
