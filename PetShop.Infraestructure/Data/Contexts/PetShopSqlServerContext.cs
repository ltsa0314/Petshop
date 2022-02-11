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
                x.ToQuery(() => ReportTopSales.FromSqlRaw(@"select top 3 p.Name,p.Image ,Quantity = sum(oi.Count)
                                                        from OrdenItems oi
                                                        inner join Productos p on oi.ProductId = p.Id
                                                        group by p.Name,p.Image
                                                        order by sum(oi.Count) desc"));
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
