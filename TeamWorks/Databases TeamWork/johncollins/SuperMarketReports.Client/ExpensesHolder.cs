using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketReports.Client
{
    public class ExpensesHolder
    {
        public ExpensesHolder(decimal expense, string date)
        {
            this.Expense = expense;
            this.Date = date;
        }

        public decimal Expense { get; set; }
        public string Date { get; set; }
    }
}
