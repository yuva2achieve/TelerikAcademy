namespace _01.Chef
{
    using System;
    using System.Linq;

    class MainClass
    {
        public static void Main(string[] args)
        {
            // Task 2
            Chef chef = new Chef();
            Potato potato = new Potato();
            if (potato != null)
            {
                bool isPeeled = potato.HasBeenPeeled();
                bool isFresh = potato.IsFresh();
                if (isPeeled && isFresh)
                {
                    chef.Cook(potato);
                }
            }
        }
    }
}
