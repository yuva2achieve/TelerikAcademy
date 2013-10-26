﻿using System;
using System.Collections.Generic;

namespace _01.SumOfCoins
{
    class SumOfCoins
    {
        static readonly int[] coinsTypes = new int[]
        {
            1,
            2,
            5
        };

        static void Main()
        {
            Console.Write("Enter S: ");
            long sumOfCoins = long.Parse(Console.ReadLine());
            IList<int> coins = GetCoinsWithSum(sumOfCoins);
            if (coins.Count > 0)
            {
                Console.WriteLine("The sum '{0}' can be formed by {1} coins and they are: {2}",
                    sumOfCoins, coins.Count, string.Join(" + ", coins));
            }
            else
            {
                Console.WriteLine("Cannot have sum '{0}' with coins {1}",
                    sumOfCoins, string.Join(", ", coins));
            }
        }

        static IList<int> GetCoinsWithSum(long sumOfCoins)
        {
            IList<int> coins = new List<int>();
            long currentSumOfCoins = 0;
            long newSum = 0;
            do
            {
                for (int i = coinsTypes.Length - 1; i >= 0; i--)
                {
                    newSum = currentSumOfCoins + coinsTypes[i];
                    if (newSum < sumOfCoins)
                    {
                        coins.Add(coinsTypes[i]);
                        currentSumOfCoins = newSum;
                        break;
                    }
                    else if (newSum == sumOfCoins)
                    {
                        coins.Add(coinsTypes[i]);
                        return coins;
                    }
                }
            }
            while (currentSumOfCoins == newSum);

            coins.Clear();
            return coins;
        }
    }
}
