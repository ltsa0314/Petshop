using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Aggregates.ProductAggregate;
using PetShop.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infraestructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly PetShopContext _contex;
        public ProductRepository(DbContext context) : base(context)
        {
            _contex = (PetShopContext)context;
        }

        public List<ReportTopSales> GetReportTopSales()
        {
            var entities = _contex.ReportTopSales.ToList();
            return entities;

        }
    }
}
