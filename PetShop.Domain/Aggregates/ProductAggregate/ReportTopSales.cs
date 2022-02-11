using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Domain.Aggregates.ProductAggregate
{
    public class ReportTopSales
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}
