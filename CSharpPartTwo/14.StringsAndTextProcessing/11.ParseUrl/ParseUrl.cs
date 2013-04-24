using System;
using System.Linq;
using System.Text;

namespace _11.ParseUrl
{
    class ParseUrl
    {
        static void Main(string[] args)
        {
            string[] separators = {"://","/"};
            StringBuilder myBuilder = new StringBuilder();
            string url = @"http://www.devbg.org/forum/index.php";
            string[] urlSplit = url.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string protocol = urlSplit[0];
            string server = urlSplit[1];
            string resource = "";
            for (int i = 2; i <urlSplit.Length ; i++)
            {
                myBuilder.AppendFormat("/{0}",urlSplit[i]);
            }
            resource = myBuilder.ToString();
            Console.WriteLine("[protocol] = {0}\n[server] = {1}\n[resource] = {2}", protocol, server, resource);
        }
    }
}
