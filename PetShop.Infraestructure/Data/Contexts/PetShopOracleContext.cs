using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PetShop.Infraestructure.Data.Contexts
{
    public class PetShopOracleContext : PetShopContext
    {
        public PetShopOracleContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetShopContext).Assembly);
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
