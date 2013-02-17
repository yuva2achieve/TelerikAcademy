using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.NumbersToText
{
    class NumbersToText
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number:");
            int number = int.Parse(Console.ReadLine());
            int thirdDigit = number % 10;
            int secondDigit = (number / 10) % 10;
            int firstDigit = ((number / 10) / 10) % 10;
            if (number >= 0 && number <=99)
            {
                switch (secondDigit)
                {
                    case 0: Console.Write(" "); break;
                    case 1: Console.Write(" "); break;
                    case 2: Console.Write("Twenty"); break;
                    case 3: Console.Write("Thirty"); break;
                    case 4: Console.Write("Forty"); break;
                    case 5: Console.Write("Fifty"); break;
                    case 6: Console.Write("Sixty"); break;
                    case 7: Console.Write("Seventy"); break;
                    case 8: Console.Write("Eighty"); break;
                    case 9: Console.Write("Ninety"); break;
                }
                if (secondDigit == 0)
                {
                    switch (thirdDigit)
                    {
                        case 0: Console.Write("Zero"); break;
                        case 1: Console.Write("One"); break;
                        case 2: Console.Write("Two"); break;
                        case 3: Console.Write("Three"); break;
                        case 4: Console.Write("Four"); break;
                        case 5: Console.Write("Five"); break;
                        case 6: Console.Write("Six"); break;
                        case 7: Console.Write("Seven"); break;
                        case 8: Console.Write("Eight"); break;
                        case 9: Console.Write("Nine"); break;
                    }
                }
                else if (secondDigit == 1)
                {
                    switch (thirdDigit)
                    {
                        case 0: Console.Write("Ten"); break;
                        case 1: Console.Write("Eleven"); break;
                        case 2: Console.Write("Twelve"); break;
                        case 3: Console.Write("Thirteen"); break;
                        case 4: Console.Write("Fourteen"); break;
                        case 5: Console.Write("Fifteen"); break;
                        case 6: Console.Write("Sixteen"); break;
                        case 7: Console.Write("Seventeen"); break;
                        case 8: Console.Write("Eightteen"); break;
                        case 9: Console.Write("Nineteen"); break;
                    }
                }
                else if (secondDigit >=2 && secondDigit <= 9)
                {
                    switch (thirdDigit)
                    {
                        case 0: Console.Write(""); break;
                        case 1: Console.Write("-one"); break;
                        case 2: Console.Write("-two"); break;
                        case 3: Console.Write("-three"); break;
                        case 4: Console.Write("-four"); break;
                        case 5: Console.Write("-five"); break;
                        case 6: Console.Write("-six"); break;
                        case 7: Console.Write("-seven"); break;
                        case 8: Console.Write("-eight"); break;
                        case 9: Console.Write("-nine"); break;
                    }
                }
            }
            else if (number >= 100 && number <= 999 )
            {
                switch (firstDigit)
                {
                    case 1: Console.Write("One hundred "); break;
                    case 2: Console.Write("Two hundred "); break;
                    case 3: Console.Write("Three hundred "); break;
                    case 4: Console.Write("Four hundred "); break;
                    case 5: Console.Write("Five hundred "); break;
                    case 6: Console.Write("Six hundred "); break;
                    case 7: Console.Write("Seven hundred "); break;
                    case 8: Console.Write("Eight hundred "); break;
                    case 9: Console.Write("Nine hundred "); break;
                }
                switch (secondDigit)
                {
                    case 0: Console.Write(" "); break;
                    case 1: Console.Write(" "); break;
                    case 2: Console.Write("twenty"); break;
                    case 3: Console.Write("thirty"); break;
                    case 4: Console.Write("torty"); break;
                    case 5: Console.Write("fifty"); break;
                    case 6: Console.Write("sixty"); break;
                    case 7: Console.Write("seventy"); break;
                    case 8: Console.Write("eighty"); break;
                    case 9: Console.Write("ninety"); break;
                }
                if (secondDigit == 0)
                {
                    switch (thirdDigit)
                    {
                        case 0: Console.Write(" "); break;
                        case 1: Console.Write("and one"); break;
                        case 2: Console.Write("and two"); break;
                        case 3: Console.Write("and three"); break;
                        case 4: Console.Write("and four"); break;
                        case 5: Console.Write("and five"); break;
                        case 6: Console.Write("and six"); break;
                        case 7: Console.Write("and seven"); break;
                        case 8: Console.Write("and eight"); break;
                        case 9: Console.Write("and nine"); break;
                    }
                }
                else if (secondDigit == 1)
                {
                    switch (thirdDigit)
                    {
                        case 0: Console.Write("and ten"); break;
                        case 1: Console.Write("and eleven"); break;
                        case 2: Console.Write("and twelve"); break;
                        case 3: Console.Write("and thirteen"); break;
                        case 4: Console.Write("and fourteen"); break;
                        case 5: Console.Write("and fifteen"); break;
                        case 6: Console.Write("and sixteen"); break;
                        case 7: Console.Write("and seventeen"); break;
                        case 8: Console.Write("and eightteen"); break;
                        case 9: Console.Write("and nineteen"); break;
                    }
                }
                else if (secondDigit >=2 && secondDigit <= 9)
                {
                    switch (thirdDigit)
                    {
                        case 0: Console.Write(""); break;
                        case 1: Console.Write("-one"); break;
                        case 2: Console.Write("-two"); break;
                        case 3: Console.Write("-three"); break;
                        case 4: Console.Write("-four"); break;
                        case 5: Console.Write("-five"); break;
                        case 6: Console.Write("-six"); break;
                        case 7: Console.Write("-seven"); break;
                        case 8: Console.Write("-eight"); break;
                        case 9: Console.Write("-nine"); break;
                    }
                }
            }
        }
    }
}
