using System;
using System.Linq;

namespace _01.SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number;
            double squareRoot;
            try
            {
                number = int.Parse(input);
                squareRoot = Math.Sqrt(number);
                if (number < 0)
                {
                    throw new ArgumentException("Number must be positive");
                }
                Console.WriteLine(squareRoot);                
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number is too big");
            }
            catch (FormatException)
            {
                Console.WriteLine("Number must be integer");
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
