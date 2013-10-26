using System;
using System.Linq;
using System.Xml;
using Supermarket.Model;
using Supermarket.Model.Expenses;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

namespace SuperMarketReports.Client
{
    public class VendorLoader
    {
        public void ParseXml()
        {
            string connectionString = "mongodb://localhost";
            var url = new MongoUrl(connectionString);
            var client = new MongoClient(url);
            var server = client.GetServer();
            var database = server.GetDatabase("ProductReports");
            database.DropCollection("SaleExpensers");

            int id = 0;
            using (XmlReader reader = XmlReader.Create("../../SalesReportsResult/Vendors-Expenses.xml"))
            {
                using (var marketContext = new SupermarketContext())
                {
                    marketContext.Database.SqlQuery<int>("delete from SaleExpensers");
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "sale"))
                        {
                            var vendorName = reader.GetAttribute("vendor");
                            id = (from vendor in marketContext.Vendors
                                  where vendor.VendorName.Equals(vendorName)
                                  select vendor.Id).FirstOrDefault();
                        }

                        if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "expenses"))
                        {
                            var month = reader.GetAttribute("month").ToString();
                            var expensePrice = decimal.Parse(reader.ReadElementString());
                           
                            // add to SQL server
                            
                            var expense = new SaleExpenser()
                            {
                                VendorId = id,
                                Expenses = expensePrice,
                                Month = month
                            };

                            //marketContext.Expenses.Add(expense);
                          
                           //  add to MongoDb

                            var expenseDocument = new BsonDocument();

                            expenseDocument["vendor-id"] = id;
                            expenseDocument["expense"] = expensePrice.ToString();
                            expenseDocument["month"] = month;

                            var collection = database.GetCollection("SaleExpensers");
                            collection.Insert(expenseDocument);

                           

                        }
                    }

                    //marketContext.SaveChanges();
                }
            }
        }
    }
}