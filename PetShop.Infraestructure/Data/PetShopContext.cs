using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Aggregates.OrderAggregate;
using PetShop.Domain.Aggregates.ProductAggregate;
using PetShop.Domain.Aggregates.UserAggregate;
using System.Linq;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetShopContext).Assembly);

            // Custom Querys


            modelBuilder.Entity<ReportTopSales>(x =>
            {
                x.HasNoKey();
                x.ToInMemoryQuery(() => ReportTopSales.FromSqlRaw(CustomQuerys.ReportTopSales));
            });

            base.OnModelCreating(modelBuilder);

            var cascadeFks = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);


            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
