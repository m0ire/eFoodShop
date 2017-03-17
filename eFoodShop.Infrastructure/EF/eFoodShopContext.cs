using System.Data.Entity;
using eFoodShop.Domain.Entities;

namespace eFoodShop.Infrastructure.EF
{
    public class eFoodShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().HasRequired(p => p.Customer);
            modelBuilder.Entity<Product>().HasMany(p => p.CartItems).WithRequired(p => p.Product);
            modelBuilder.Entity<CartItem>().HasKey(p => new {p.CartId, p.ProductId}); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
