using System;
using System.Data.Entity;
using System.Linq;
using Supermarket.Model;
using Supermarket.Model.Migrations;

namespace SuperMarketReports.Client
{
    class DataReporting_Main
    {
        static void Main(string[] args)
        {
            //System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketContext, Configuration>());
            // using (var c = new SupermarketContext()) { c.Expenses.ToList(); }
            //DbMigrator.MigrateFromMySqlToMSSql();

            ReportsMigrator r = new ReportsMigrator(@"C:\Users\Borislav\Desktop\Databases-Teamwork-Practical-Project\Sample-Sales-Reports.zip");
            r.ExtractReports();
            r.GetAllReports();
            //r.FillTable();
            r.DeleteReports();
           //----------------------------------------------------------------------------------------

           // XmlReportCreator reporter = new XmlReportCreator();
           // reporter.GenerateXmlFileReportByVendors();
           ////-------------------------------------------------------------------------------------------

           // ProductReportCreator reportCreator = new ProductReportCreator();
           // reportCreator.CreateReport();

           ////--------------------------------------------------------------------------------------

           // VendorLoader v = new VendorLoader();
           // v.ParseXml();

           //// ------------------------------------------------------------------

           // VendorsTotalReportCreator creator = new VendorsTotalReportCreator();
           // creator.CreateExcel();
           // creator.ReadReportsFromMongo();
        }
    }
}
