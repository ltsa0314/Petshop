using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Aggregates.OrderAggregate;
using PetShop.Domain.Aggregates.ProductAggregate;
using PetShop.Domain.Aggregates.UserAggregate;

namespace PetShop.Infraestructure.Data
{
    public class PetShopContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ReportTopSales> ReportTopSales { get; set; }

        public PetShopContext(DbContextOptions options) : base(options)
        {

        }
    }
}
