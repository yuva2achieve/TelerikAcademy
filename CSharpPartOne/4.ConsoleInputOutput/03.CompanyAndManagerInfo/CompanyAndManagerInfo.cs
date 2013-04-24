using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyAndManagerInfo
{
    class CompanyAndManagerInfo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter company name:");
            string companyName = Console.ReadLine();
            Console.WriteLine("Please enter company address:");
            string companyAddress = Console.ReadLine();
            Console.WriteLine("Please enter company phone number:");
            string companyPhone = Console.ReadLine();
            Console.WriteLine("Please enter company fax number:");
            string companyFax = Console.ReadLine();
            Console.WriteLine("Please enter company website:");
            string companyWebsite = Console.ReadLine();
            Console.WriteLine("Please enter manager's first name:");
            string managerFirstName = Console.ReadLine();
            Console.WriteLine("Please enter manager's last name:");
            string managerLastName = Console.ReadLine();
            Console.WriteLine("Please enter manager's age:");
            string managerAge = Console.ReadLine();
            Console.WriteLine("Please enter manager's phone number:");
            string managerPhone = Console.ReadLine();
            Console.WriteLine("Company name is {0}.It's address is {1}.",companyName, companyAddress);
            Console.WriteLine("You can call them on {0},fax them on {1} or check their website {2}. ", companyPhone, companyFax, companyWebsite);
            Console.WriteLine("{0} {1} is manager in {2}.", managerFirstName, managerLastName, companyName);
            Console.WriteLine("He/She is {0} years old.", managerAge);
            Console.WriteLine("You can contact him/her on {0}.", managerPhone);
        }
    }
}
