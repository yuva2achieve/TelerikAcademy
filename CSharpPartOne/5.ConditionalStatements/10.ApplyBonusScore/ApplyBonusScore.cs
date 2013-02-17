using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.ApplyBonusScore
{
    class ApplyBonusScore
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter digit between 1 and 9:");
            int digit = int.Parse(Console.ReadLine());
            if ((digit >= 1) && (digit <= 3))
            {
                switch (digit)
                {
                    case 1: digit *= 10;
                        Console.WriteLine(digit);
                        break;
                    case 2: digit *= 10;
                        Console.WriteLine(digit);
                        break;
                    case 3: digit *= 10;
                        Console.WriteLine(digit);
                        break;
                }
            }
            else if ((digit >= 4) && (digit <= 6))
            {
                switch (digit)
                {
                    case 4: digit *= 100;
                        Console.WriteLine(digit);
                        break;
                    case 5: digit *= 100;
                        Console.WriteLine(digit);
                        break;
                    case 6: digit *= 100;
                        Console.WriteLine(digit);
                        break;
                }
            }
            else if ((digit >= 7) && (digit <= 9))
            {
                switch (digit)
                {
                    case 7: digit *= 1000;
                        Console.WriteLine(digit);
                        break;
                    case 8: digit *= 1000;
                        Console.WriteLine(digit);
                        break;
                    case 9: digit *= 1000;
                        Console.WriteLine(digit);
                        break;
                }
            }
            else if ((digit == 0) || (digit > 9))
            {
                Console.WriteLine("Enter valid digit!");
            }
        }
    }
}
