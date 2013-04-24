namespace _02.Statistics
{
    using System;
    using System.Linq;

    public class Statistics
    {
        private static void Main(string[] args)
        {
        }

        private void PrintStatistics(double[] array, int arrayElementsCount)
        {
            double maximalArrayValue = array[0];
            for (int index = 1; index < arrayElementsCount; index++)
            {
                if (array[index] > maximalArrayValue)
                {
                    maximalArrayValue = array[index];
                }
            }

            this.PrintMaximalValue(maximalArrayValue);
            double minimalArrayValue = array[0];
            for (int index = 1; index < arrayElementsCount; index++)
            {
                if (array[index] < minimalArrayValue)
                {
                    minimalArrayValue = array[index];
                }
            }

            this.PrintMinimalValue(minimalArrayValue);
            double sumOfArrayElements = 0;
            for (int index = 0; index < arrayElementsCount; index++)
            {
                sumOfArrayElements += array[index];
            }

            double averageArrayValue = sumOfArrayElements / arrayElementsCount;
            this.PrintAverageValue(averageArrayValue);
        }
  
        private void PrintAverageValue(double averageValue)
        {
            Console.WriteLine("Average value of array elements is: {0}", averageValue);
        }
  
        private void PrintMinimalValue(double maximalValue)
        {
            Console.WriteLine("Maximal value in the array is: {0}", maximalValue);
        }
  
        private void PrintMaximalValue(double minimalValue)
        {
            Console.WriteLine("Minimal value in the array is: {0}", minimalValue);
        }
    }
}
