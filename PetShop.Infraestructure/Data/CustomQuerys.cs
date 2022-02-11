using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Infraestructure.Data
{
    public static class CustomQuerys
    {
        public const string ReportTopSales = @"select top 3 p.Name,p.Image ,Quantity = sum(oi.Count)
                                                        from OrdenItems oi
                                                        inner join Productos p on oi.ProductId = p.Id
                                                        group by p.Name,p.Image
                                                        order by sum(oi.Count) desc";
    }
}
