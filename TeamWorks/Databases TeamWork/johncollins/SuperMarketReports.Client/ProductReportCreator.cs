using System;
using System.Data.Entity;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Supermarket.Model;
using System.IO;

namespace SuperMarketReports.Client
{
    public class ProductReportCreator
    {
        public void CreateReport()
        {
            string connectionString = "mongodb://localhost";
            var url = new MongoUrl(connectionString);
            var client = new MongoClient(url);
            var server = client.GetServer();
            var database = server.GetDatabase("ProductReports");

            database.DropCollection("ProductReports");
            var collection = database.GetCollection("ProductReports");
            using (var supermarket = new SupermarketContext())
            {
                var productsById = supermarket.SalesReports.Include("Vendors").Include("Products").GroupBy(r => r.ProductId).ToList();
                foreach (var group in productsById)
                {
                    var firstProduct = group.First();
                    var productDocument = new BsonDocument();

                    productDocument["product-id"] = firstProduct.ProductId;
                    productDocument["product-name"] = firstProduct.Product.ProductName.Replace("\"", "\\\"");
                    productDocument["vendor-id"] = firstProduct.Product.VendorId;
                    productDocument["vendor-name"] = firstProduct.Product.Vendor.VendorName.Replace("\"", "\\\"");
                    productDocument["total-quantity-sold"] = group.Sum(g => g.Quantity);
                    productDocument["total-incomes"] = group.Sum(g => g.Sum).ToString();


                    collection.Insert(productDocument);

                    using (StreamWriter documentWriter = new StreamWriter(string.Format("../../Product-Reports/{0}.json", productDocument["product-id"]), false))
                    {
                        documentWriter.WriteLine("{");
                        documentWriter.WriteLine("\t\"product-id\": \"{0}\"", productDocument["product-id"]);
                        documentWriter.WriteLine("\t\"product-name\": \"{0}\"", productDocument["product-name"]);
                        documentWriter.WriteLine("\t\"vendor-name\": \"{0}\"", productDocument["vendor-name"]);
                        documentWriter.WriteLine("\t\"total-quantity-sold\": \"{0}\"", productDocument["total-quantity-sold"]);
                        documentWriter.WriteLine("\t\"total-incomes\": \"{0}\"", productDocument["total-incomes"]);
                        documentWriter.WriteLine("}");
                    }
                }
            }
        }
    }
}
