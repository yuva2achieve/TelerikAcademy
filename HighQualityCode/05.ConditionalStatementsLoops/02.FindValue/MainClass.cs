namespace _02.FindValue
{
    using System;
    using System.Linq;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            int[] values = new int[100];
            int expectedValue = int.Parse(Console.ReadLine());
            bool valueFound = false;
            for (int index = 0; index < 100; index++)
            {
                Console.WriteLine(values[index]);

                if (index % 10 == 0)
                {
                    if (values[index] == expectedValue)
                    {
                        valueFound = true;
                        break;
                    }
                }
            }

            // More code here
            if (valueFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
