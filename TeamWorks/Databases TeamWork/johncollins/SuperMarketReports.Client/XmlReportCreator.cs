using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Model;
using Supermarket.Model.ReportsByVendors;
using System.Xml.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace SuperMarketReports.Client
{
    public class XmlReportCreator
    {

        public XmlReportCreator()
        {
        }

        private IEnumerable<VendorReport> GetSalesReportsByVendor()
        {
            using (var marketContext = new SupermarketContext())
            {
                var query = (@"select 
                            SUM(SalesReports.Sum) as [TotalSum],
                            SalesReports.Date,
                            Vendors.VendorName
                            from SalesReports
                            Inner Join Products
                            on Products.Id = SalesReports.ProductId
                            Inner Join Vendors
                            on Vendors.Id=Products.VendorId
                            Group by SalesReports.Date, Vendors.VendorName");

                var result = marketContext.Database.SqlQuery<VendorReport>(query);

                return result.ToList<VendorReport>();
            }
        }

        private Dictionary<string, List<VendorReport>> CreateDictionary(IEnumerable<VendorReport> list)
        {
            Dictionary<string, List<VendorReport>> dic = new Dictionary<string, List<VendorReport>>();
            foreach (var item in list)
            {
                if (dic.ContainsKey(item.VendorName))
                {
                    dic[item.VendorName].Add(item);
                }
                else
                {
                    dic.Add(item.VendorName, new List<VendorReport>() { item });
                }
            }

            return dic;
        }

        private void GenerateXmlFile(Dictionary<string, List<VendorReport>> dic)
        {
            XDocument doc = new XDocument();
            XElement sales = new XElement("sales");
            doc.Add(sales);

            foreach (var item in dic)
            {
                var sale = new XElement("sale");
                sale.Add(new XAttribute("vendor",item.Key));
                foreach (var s in item.Value)
                {
                    var summary = new XElement("summary");
                    summary.Add(new XAttribute("date", s.Date.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)));
                    summary.Add(new XAttribute("total-sum", s.TotalSum));
                    sale.Add(summary);
                }
                sales.Add(sale);
            }

            doc.Save("../../SalesReportsResult/Sales-by-Vendors-report.xml");
        }

        public void GenerateXmlFileReportByVendors()
        {
            var listOfReports = GetSalesReportsByVendor();
            var dicOfReports = CreateDictionary(listOfReports);
            GenerateXmlFile(dicOfReports);
        }
    }
}