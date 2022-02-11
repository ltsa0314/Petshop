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

    }
}
