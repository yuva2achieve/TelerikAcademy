using Product.Model;
using System;
using System.Linq;
using Supermarket.Model;
using System.Data.Entity;
using Supermarket.Model.Migrations;
using System.Data.SqlClient;

namespace Supermarket.Model.Migrations
{
    public static class DbMigrator
    {
        public static void MigrateFromMySqlToMSSql()
        {

            using (var productContext = new ProductContext())
            {
                using (var supermarketContext = new SupermarketContext())
                {
                    MigrateVendorsTable(productContext, supermarketContext);
                    MigrateMeasuresTable(productContext, supermarketContext);
                    MigrateProductsTable(productContext, supermarketContext);

                    supermarketContext.SaveChanges();
                }
            }
        }

        private static void MigrateMeasuresTable(ProductContext productContext,
            SupermarketContext supermarketContext)
        {
            var productTable = productContext.Measures;
            var supermarketTable = supermarketContext.Measures;
            foreach (var item in productTable)
            {
                var newItem = new Measure() { Id = item.Id, MeasureName = item.MeasureName };
                supermarketTable.Add(newItem);
            }
        }

        private static void MigrateProductsTable(ProductContext productContext,
            SupermarketContext supermarketContext)
        {
            var productTable = productContext.Products;
            var supermarketTable = supermarketContext.Products;
            foreach (var item in productTable)
            {
                var newItem = new Product.Model.Product() { Id = item.Id, VendorId = item.VendorId, ProductName = item.ProductName, MeasureId = item.MeasureId, BasePrice = item.BasePrice };
                supermarketTable.Add(newItem);
            }
        }

        private static void MigrateVendorsTable(ProductContext productContext,
            SupermarketContext supermarketContext)
        {
            var productTable = productContext.Vendors;
            var supermarketTable = supermarketContext.Vendors;
            foreach (var item in productTable)
            {
                var newItem = new Vendor() { Id = item.Id, VendorName = item.VendorName };
                supermarketTable.Add(newItem);
            }
        }
    }
}