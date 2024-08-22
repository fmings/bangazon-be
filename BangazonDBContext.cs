using Microsoft.EntityFrameworkCore;
using bangazon.Data;
using bangazon.Models;


namespace bangazon
{
    public class BangazonDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public BangazonDBContext(DbContextOptions<BangazonDBContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(UserData.Users);
            modelBuilder.Entity<ProductItem>().HasData(ProductItemData.ProductItems);
        }
    }

    
}
