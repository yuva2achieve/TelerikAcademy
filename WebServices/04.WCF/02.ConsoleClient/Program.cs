using System;
using System.Linq;
using _02.ConsoleClient.ServiceReference1;

namespace _02.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            SimpleServiceClient client = new SimpleServiceClient();

            DateTime testDate = DateTime.Now;
            Console.WriteLine(client.GetDayOfWeekInBulgarian(testDate));
            // Use the 'client' variable to call operations on the service.

            // Always close the client.
            client.Close();
        }
    }
}
