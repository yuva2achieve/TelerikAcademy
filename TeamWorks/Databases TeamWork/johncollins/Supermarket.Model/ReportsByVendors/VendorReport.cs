using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model.ReportsByVendors
{
    public class VendorReport
    {
        public decimal TotalSum { get; set; }

        public DateTime Date { get; set; }

        public string VendorName { get; set; }
    }
}