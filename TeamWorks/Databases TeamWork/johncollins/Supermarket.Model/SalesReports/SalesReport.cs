using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model.SalesReports
{
    public class SalesReport
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int SupermarketId { get; set; }

        public virtual Supermarket Supermarket { get; set; }

        public int ProductId { get; set; }

        public virtual Product.Model.Product Product { get; set; }

        public double Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Sum { get; set; }
    }
}
