using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.KnapsackProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            int m = 10;
            Product[] products = new Product[]
            {
                new Product("Beer", 3, 2),
                new Product("Vodka", 8, 12),
                new Product("Cheese", 4, 5),
                new Product("Nuts", 1, 4),
                new Product("Ham", 2, 3),
                new Product("Whiskey", 8, 13),
            };

            int[,] values = new int[n + 1, m + 1];
            int[,] keep = new int[n + 1, m + 1];

            for (int col = 0; col < values.GetLength(1); col++)
            {
                values[0, col] = 0;
                keep[0, col] = 0;
            }

            for (int itemIndex = 1; itemIndex < values.GetLength(0); itemIndex++)
            {
                for (int weight = 0; weight < values.GetLength(1); weight++)
                {
                    var currentProduct = products[itemIndex - 1];

                    if (currentProduct.Weight <= weight)
                    {
                        int upperRowCost = values[itemIndex - 1, weight];

                        if (upperRowCost != 0)
                        {
                            var previousProduct = products[itemIndex - 2];

                            if (currentProduct.Weight + previousProduct.Weight <= weight)
                            {
                                values[itemIndex, weight] = currentProduct.Cost + upperRowCost;
                                keep[itemIndex, weight] = 1;
                            }
                            else
                            {
                                if (upperRowCost > currentProduct.Cost)
                                {
                                    values[itemIndex, weight] = upperRowCost;
                                    keep[itemIndex, weight] = 0;
                                }
                                else
                                {
                                    values[itemIndex, weight] = currentProduct.Cost;
                                    keep[itemIndex, weight] = 1;
                                }
                            }
                        }
                        else
                        {
                            values[itemIndex, weight] = currentProduct.Cost;
                            keep[itemIndex, weight] = 1;
                        }
                    }
                    else
                    {
                        values[itemIndex, weight] = 0;
                        keep[itemIndex, weight] = 0;
                    }
                }
            }

            int i = n;
            int w = m;

            List<Product> knapsack = new List<Product>();

            while (i >= 0 && w >= 0)
            {
                if (keep[i,w] == 1)
                {
                    var product = products[i - 1];
                    i--;
                    w -= product.Weight;
                    knapsack.Add(product);
                }
                else
                {
                    i--;
                }
            }

            Console.WriteLine("Knapsack: {0}", string.Join(", ",knapsack.Select(x => x.Name)));
        }
    }
}
