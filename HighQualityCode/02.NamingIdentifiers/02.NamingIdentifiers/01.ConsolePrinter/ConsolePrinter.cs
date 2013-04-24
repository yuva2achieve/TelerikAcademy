namespace _01.ConsolePrinter
{
    using System;
    using System.Linq;

    public class ConsolePrinter
    {
        const int MaxCount = 6;

        public static void Main()
        {
            BoolHandler instance =
              new BoolHandler();
            instance.PrintBoolAsString(true);
        }

        public class BoolHandler
        {
            public void PrintBoolAsString(bool argumentToPrint)
            {
                string argumentAsString = argumentToPrint.ToString();
                Console.WriteLine(argumentAsString);
            }

        }
    }
}
