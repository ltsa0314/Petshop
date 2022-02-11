using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Aggregates.ProductAggregate;
using System.Linq;

namespace PetShop.Infraestructure.Data.Contexts
{
    public class PetShopSqlServerContext : PetShopContext
    {

        public PetShopSqlServerContext(DbContextOptions options) : base(options)
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
