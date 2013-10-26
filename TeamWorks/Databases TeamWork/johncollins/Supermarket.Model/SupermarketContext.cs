using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Model;

namespace Supermarket.Model
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext()
            : base("Supermarket")
        {
        }

        public DbSet<Product.Model.Product> Products { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Supermarket.Model.SalesReports.Supermarket> Supermarkets { get; set; }

        public DbSet<Supermarket.Model.SalesReports.SalesReport> SalesReports { get; set; }

        public DbSet<Supermarket.Model.Expenses.SaleExpenser> Expenses { get; set; }
    }
}
