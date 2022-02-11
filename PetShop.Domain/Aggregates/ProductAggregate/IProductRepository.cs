using PetShop.Domain.SeedWork.Contracts;
using System.Collections.Generic;

namespace PetShop.Domain.Aggregates.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {
        List<ReportTopSales> GetReportTopSales();
    }
}
