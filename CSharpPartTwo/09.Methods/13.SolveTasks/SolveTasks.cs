using System;
using System.Linq;
using System.Text;

namespace _13.SolveTasks
{
    class SolveTasks
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You must choose one of the three options!");
            Console.WriteLine("1 - reverse digits of a number");
            Console.WriteLine("2 - calculate average of a sequence of numbers");
            Console.WriteLine("3 - solve a*x + b = 0");
            byte userChoice = byte.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:ReverseDigits();break;
                case 2:CalculateAverage();break;
                case 3: SolveEquation(); break;
            }
        }

        static void ReverseDigits()
        {
            string number = GetNumValue(); 
            StringBuilder reversed = new StringBuilder();
            for (int i = number.Length - 1; i >= 0; i--)
            {
                reversed.Append(number[i]);
            }
            Console.WriteLine("Reversed number: {0}",reversed);
        }

        static string GetNumValue()
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            return input;
        }

        static void CalculateAverage()
        {
            int[] sequenceElements = GetArrayValues();
            int sum = sequenceElements.Sum();
            int average = sum / sequenceElements.Length;
            Console.WriteLine("Average is: {0}", average);
        }
  
         static int[] GetArrayValues()
        {
            Console.Write("Enter element count: ");
            int n = int.Parse(Console.ReadLine());
            int[] myArray = new int[n];
            Console.WriteLine("Enter element values:");
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = int.Parse(Console.ReadLine());
            }
            return myArray;
        }

         static void SolveEquation()
         {
             decimal a = GetValueA();
             decimal b = GetValueB();
             decimal result = (-b) / a;
             Console.WriteLine("Result is: {0}", result);
         }

         static decimal GetValueA()
         {
             Console.Write("Enter A: ");
             decimal input = decimal.Parse(Console.ReadLine());
             return input;
         }

         static decimal GetValueB()
         {
             Console.Write("Enter B: ");
             decimal input = decimal.Parse(Console.ReadLine());
             return input;
         }
    }
}
