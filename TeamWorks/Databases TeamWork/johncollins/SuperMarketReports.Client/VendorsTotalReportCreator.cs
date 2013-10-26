using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoDB.Driver;
using OfficeOpenXml;
using Taxes.Model;

namespace SuperMarketReports.Client
{
    public class VendorsTotalReportCreator
    {
        private const string ReportName = @"Products-Total-Report.xlsx";
        private const string MongoConnectionString = "mongodb://localhost";
        private FileInfo fileInfo = new FileInfo(ReportName);
        private Dictionary<int, List<ExpensesHolder>> expenses;

        public VendorsTotalReportCreator()
        {
            this.expenses = new Dictionary<int, List<ExpensesHolder>>();
        }

        public void ReadReportsFromMongo()
        {
            var url = new MongoUrl(MongoConnectionString);
            var client = new MongoClient(url);
            var server = client.GetServer();
            var database = server.GetDatabase("ProductReports");
            var productReports = database.GetCollection("ProductReports");
            var reports = productReports.FindAll();

            int vendorPosition = 2;
            int incomesPosition = 2;
            int expensesPosition = 2;
            int taxesPosition = 2;
            int financialResultPosition = 2;



            var vendorExpenses = database.GetCollection("SaleExpensers");
            var expenses = vendorExpenses.FindAll();
            foreach (var item in expenses)
            {
                int id = item["vendor-id"].ToInt32();
                decimal expense = (decimal)item["expense"].ToDouble();
                string date = item["month"].ToString();

                if (!this.expenses.ContainsKey(id))
                {
                    this.expenses[id] = new List<ExpensesHolder>();
                }

                ExpensesHolder newItem = new ExpensesHolder(expense, date);
                this.expenses[id].Add(newItem);

            }

            foreach (var item in reports)
            {
                string productName = item["product-name"].ToString();
                int vendorID = item["vendor-id"].ToInt32();
                string vendorName = item["vendor-name"].ToString();
                decimal totalIncomes = (decimal)(item["total-incomes"].ToDouble());
                decimal expense = this.GetExpensesForCurrentMonth(vendorID);

                this.AddTax(productName);

                decimal taxPercent = this.GetTaxPercentForProduct(productName);
                decimal calculatedTax = totalIncomes * (taxPercent / 100m);
                decimal result = this.CalculateFinancialResult(totalIncomes, expense, calculatedTax);

                this.FillVendors(vendorName, vendorPosition);
                this.FillIncomes(totalIncomes, incomesPosition);
                this.FillTaxPercents(calculatedTax, taxesPosition);
                this.FillExpenses(expense, expensesPosition);
                this.FillFinancialResults(result, financialResultPosition);

                vendorPosition++;
                incomesPosition++;
                expensesPosition++;
                taxesPosition++;
                financialResultPosition++;
            }
        }

        public void AddTax(string productName)
        {
            VendorsTotalReportEntities context = new VendorsTotalReportEntities();

            using (context)
            {
                Random rand = new Random();
                int randomTaxPercent = rand.Next(10, 21);

                var tax = context.Taxes.Where(x => x.ProductName == productName).FirstOrDefault();

                if (tax == null)
                {
                    var newTax = new Tax()
                    {
                      ProductName = productName,
                      TaxPercent = randomTaxPercent
                    };

                    context.Taxes.Add(newTax);
                    context.SaveChanges();
                }
            }
        }

        public void CreateExcel()
        {
            ExcelPackage newExcelFile = new ExcelPackage(this.fileInfo);
            var worksheet = newExcelFile.Workbook.Worksheets.Add("Report");
            worksheet.Column(0).Width = 20d;
            worksheet.Column(1).Width = 15d;
            worksheet.Column(2).Width = 15d;
            worksheet.Column(3).Width = 15d;
            worksheet.Column(4).Width = 15d;
            worksheet.Cells["A1"].Value = "Vendor";
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["B1"].Value = "Incomes";
            worksheet.Cells["B1"].Style.Font.Bold = true;
            worksheet.Cells["C1"].Value = "Expenses";
            worksheet.Cells["C1"].Style.Font.Bold = true;
            worksheet.Cells["D1"].Value = "Taxes";
            worksheet.Cells["D1"].Style.Font.Bold = true;
            worksheet.Cells["E1"].Value = "Financial Result";
            worksheet.Cells["E1"].Style.Font.Bold = true;
            newExcelFile.Save();
        }

        private void FillVendors(string vendor, int position)
        {
            ExcelPackage p = new ExcelPackage(this.fileInfo);
            var worksheet = p.Workbook.Worksheets["Report"];
            worksheet.Cells["A" + position].Value = vendor;
            p.Save();
        }

        private void FillIncomes(decimal incomes, int position)
        {
            ExcelPackage p = new ExcelPackage(this.fileInfo);
            var worksheet = p.Workbook.Worksheets["Report"];
            worksheet.Cells["B" + position].Value = incomes;
            p.Save();
        }

        private void FillExpenses(decimal expenses, int position)
        {
            ExcelPackage p = new ExcelPackage(this.fileInfo);
            var worksheet = p.Workbook.Worksheets["Report"];
            worksheet.Cells["C" + position].Value = expenses;
            p.Save();
        }

        private void FillTaxPercents(decimal taxPercent, int position)
        {
            ExcelPackage p = new ExcelPackage(this.fileInfo);
            var worksheet = p.Workbook.Worksheets["Report"];
            worksheet.Cells["D" + position].Value = taxPercent;
            p.Save();
        }

        private void FillFinancialResults(decimal result, int position)
        {
            ExcelPackage p = new ExcelPackage(this.fileInfo);
            var worksheet = p.Workbook.Worksheets["Report"];
            worksheet.Cells["E" + position].Value = result;
            p.Save();
        }
        
        private decimal GetTaxPercentForProduct(string productName)
        {
            VendorsTotalReportEntities context = new VendorsTotalReportEntities();
            var taxPercent = 0m;
            using (context)
            {
                taxPercent = context.Taxes.Where(x => x.ProductName == productName).Select(x => x.TaxPercent).FirstOrDefault();
            }

            return taxPercent;
        }

        private decimal GetExpensesForCurrentMonth(int vendorID)
        {
            decimal expense = -1;

            if (this.expenses.ContainsKey(vendorID))
            {
                expense = this.expenses[vendorID].Where(x => IsCorrectMonth(x.Date)).Select(x => x.Expense).FirstOrDefault();
            }

            return expense;
        }

        private decimal CalculateFinancialResult(decimal incomes, decimal expenses, decimal taxes)
        {
            return incomes - expenses - taxes;
        }

        private bool IsCorrectMonth(string date)
        {
            int curMonth = DateTime.Now.Month;

            string[] args = date.Split('-');
            string month = args[0].ToLower();

            switch (curMonth)
            {
                case 1:
                    if (month == "jan")
                    {
                        return true;
                    }
                    break;
                case 2:
                    if (month == "feb")
                    {
                        return true;
                    }
                    break;
                case 3:
                    if (month == "mar")
                    {
                        return true;
                    }
                    break;
                case 4:
                    if (month == "apr")
                    {
                        return true;
                    }
                    break;
                case 5:
                    if (month == "may")
                    {
                        return true;
                    }
                    break;
                case 6:
                    if (month == "jun")
                    {
                        return true;
                    }
                    break;
                case 7:
                    if (month == "jul")
                    {
                        return true;
                    }
                    break;
                case 8:
                    if (month == "aug")
                    {
                        return true;
                    }
                    break;
                case 9:
                    if (month == "sep")
                    {
                        return true;
                    }
                    break;
                case 10:
                    if (month == "oct")
                    {
                        return true;
                    }
                    break;
                case 11:
                    if (month == "nov")
                    {
                        return true;
                    }
                    break;
                case 12:
                    if (month == "dec")
                    {
                        return true;
                    }
                    break;
                default:
                    return false;
            }

            return false;
        }
    }
}
