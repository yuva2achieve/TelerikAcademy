using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ChooseAVariable
{
    class ChooseAVariable
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose variable type.");
            Console.WriteLine("Choose 1 for Int");
            Console.WriteLine("Choose 2 for Double");
            Console.WriteLine("Choose 3 for String");
            int intVariable;
            double doubleVariable;
            string stringVariable;
            byte varChoice = byte.Parse(Console.ReadLine());
            switch (varChoice)
            {
                case 1: Console.WriteLine("You selected Int variable");
                        Console.WriteLine("Please enter value of the variable:");
                        intVariable = int.Parse(Console.ReadLine());
                        intVariable += 1;
                        Console.WriteLine(intVariable);
                        break;
                case 2: Console.WriteLine("You selected Double variable");
                        Console.WriteLine("Please enter value of the variable:");
                        doubleVariable = double.Parse(Console.ReadLine());
                        doubleVariable += 1;
                        Console.WriteLine(doubleVariable);
                        break;
                case 3: Console.WriteLine("You selected String variable");
                        Console.WriteLine("Please enter value of the variable:");
                        stringVariable = Console.ReadLine();
                        stringVariable += "*";
                        Console.WriteLine(stringVariable);
                        break;
            }
        }
    }
}
