using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PrintGreaterNumber
{
    class PrintGreaterNumber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter first number:");
            int firstNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter second number:");
            int secondNum = int.Parse(Console.ReadLine());
            int greaterNum = Math.Max(firstNum, secondNum);
            Console.WriteLine("Greater number is:{0}", greaterNum);
        }
    }
}
