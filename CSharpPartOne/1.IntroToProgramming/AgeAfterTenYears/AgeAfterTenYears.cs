using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Write a program to read your age from the console
 * and print how old you will be after 10 years.*/
namespace AgeAfterTenYears
{
    class AgeAfterTenYears
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your current age: ");
            int currentAge = int.Parse(Console.ReadLine());
            int ageAfterTenYears = currentAge + 10;
            Console.WriteLine("Your age after 10 years will be: "+ageAfterTenYears);
        }
    }
}
