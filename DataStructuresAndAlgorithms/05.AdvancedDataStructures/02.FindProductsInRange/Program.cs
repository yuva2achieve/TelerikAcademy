using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.FindProductsInRange
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OrderedBag<Product> items = new OrderedBag<Product>();
            int itemsCount = 500000;

            Stopwatch timer = new Stopwatch();
            timer.Start();
            items.AddItems(itemsCount);
            timer.Stop();
            Console.WriteLine("Added {0} items in {1}", itemsCount, timer.Elapsed);
            timer.Reset();

            List<Product> itemsInRange = new List<Product>();
            int numberOfSearches = 10000;
            timer.Start();
            for (int i = 0; i < numberOfSearches; i++)
            {
                Random rand = new Random();
                int minPrice = rand.Next(0, itemsCount);
                int maxPrice = rand.Next(0, itemsCount);
                if (minPrice > maxPrice)
                {
                    int temp = minPrice;
                    minPrice = maxPrice;
                    maxPrice = temp;
                }

                Product minProduct = new Product("Min", minPrice);
                Product maxProduct = new Product("Max", maxPrice);

                itemsInRange.AddRange(items.Range(minProduct, true, maxProduct, true).Take(20));
            }

            timer.Stop();
            Console.WriteLine("Searched {0} times in {1}", numberOfSearches, timer.Elapsed);
            Console.WriteLine(itemsInRange.Count);
        }
    }
}
