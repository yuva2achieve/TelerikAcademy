using System;
using System.Globalization;
using System.Linq;

namespace _01.SimpleWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SimpleService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SimpleService.svc or SimpleService.svc.cs at the Solution Explorer and start debugging.
    public class SimpleService : ISimpleService
    {

        public string GetDayOfWeekInBulgarian(DateTime date)
        {
            IFormatProvider culture = new CultureInfo("bg-BG");
            string dateAsString = date.ToString("dddd", new CultureInfo("bg-BG"));

            return dateAsString;
        }
    }
}
