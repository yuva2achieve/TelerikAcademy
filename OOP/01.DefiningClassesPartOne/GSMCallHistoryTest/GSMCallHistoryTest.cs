using System;
using System.Linq;
using MobilePhone.Common;

namespace GSMCallHistoryTest
{
    class GSMCallHistoryTest
    {
        static void Main(string[] args)
        {
            // Creating instance of GSM class and adding some calls
            GSM justTest = new GSM("Galaxy S", "Samsung", "Not me");
            justTest.AddCall(new Call(new DateTime(2013, 2, 25), "0895548299", 100));
            justTest.AddCall(new Call(new DateTime(2013, 2, 25), "0895548299", 200));
            justTest.AddCall(new Call(new DateTime(2013, 2, 25), "0895548299", 150));
            justTest.AddCall(new Call(new DateTime(2013, 2, 25), "0895548299", 170));
            // Printing call history
            foreach (var call in justTest.CallHistory)
            {
                Console.WriteLine(call);
            }
            // Printing total price of the calls
            var callsPrice = justTest.CalculateCallsPrice(0.37m);
            Console.WriteLine("{0}lv", callsPrice);
            // Removing longest call from call history
            int longestCall = int.MinValue;
            int longestCallPosition = 0;
            for (int i = 0; i < justTest.CallHistory.Count; i++)
            {
                if (justTest.CallHistory[i].Duration > longestCall)
                {
                    longestCall = justTest.CallHistory[i].Duration;
                    longestCallPosition = i;
                }
            }
            justTest.RemoveCall(longestCallPosition);
            // Printing call history
            foreach (var call in justTest.CallHistory)
            {
                Console.WriteLine(call);
            }
            // Clearing call history
            justTest.ClearCallHistory();
            // Printing call history
            foreach (var call in justTest.CallHistory)
            {
                Console.WriteLine(call);
            }
        }
    }
}
