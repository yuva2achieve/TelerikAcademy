using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private List<string> dataUnits = new List<string>() { "Byte", "KiloByte", "MegaByte", "GigaByte", "TeraByte" };
        public ActionResult Index()
        {
            ViewBag.types = this.dataUnits;
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(CalculatorValue val)
        {
            List<decimal> result = new List<decimal>();
            for (int i = 0; i < this.dataUnits.Count; i++)
            {
                if (i == val.Type)
                {
                    result.Add(val.Value);
                }
                else
                {
                    if (i < val.Type)
                    {
                        result.Add(val.Value * (decimal)Math.Pow(1024, val.Type - i));
                    }
                    else
                    {
                        result.Add(val.Value / (decimal)Math.Pow(1024, i - val.Type));
                    }
                }
            }
            ViewBag.types = this.dataUnits;
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}