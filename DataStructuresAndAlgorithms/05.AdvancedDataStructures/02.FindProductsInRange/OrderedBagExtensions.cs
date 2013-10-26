using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.FindProductsInRange
{
    public static class OrderedBagExtensions
    {
        public static void AddItems(this OrderedBag<Product> bag, int itemsCount)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                Product newItem = new Product("Item" + i, i);
                bag.Add(newItem);
            }
        }
    }
}
