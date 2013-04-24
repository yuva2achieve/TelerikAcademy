using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.SubstractionAndMultiplication
{
    class SubstractionAndMultiplication
    {
        static void Main(string[] args)
        {
            //Polynomial coefficients are entered in reversed order
            var firstPolynomial = new List<int> { -3, 1, 3 };
            var secondPolynomial = new List<int> { -1, 1};
            var multiplicationResult = new List<int>(PolynomialMultiplication(firstPolynomial,secondPolynomial));
            var substractionResult = new List<int>(PolynomialSubstraction(firstPolynomial,secondPolynomial));
            Console.WriteLine("Multiplication:");
            for (int i = multiplicationResult.Count - 1; i >= 0; i--)
            {
                Console.Write("{0}x^{1} ", multiplicationResult[i], i);
            }
            Console.WriteLine();
            Console.WriteLine("Substraction:");
            for (int i = substractionResult.Count - 1; i >= 0; i--)
            {
                Console.Write("{0}x^{1} ", substractionResult[i], i);
            }
        }

        static List<int> PolynomialSubstraction(List<int> polynomialA, List<int> polynomialB)
        {
            List<int> result = new List<int>();
            if (polynomialA.Count != polynomialB.Count)
            {
                AddLeadingZeros(polynomialA, polynomialB);
            }
            for (int i = 0; i < polynomialA.Count; i++)
            {
                result.Add(polynomialA[i] - polynomialB[i]);
            }
            return result;
        }

        static int[] PolynomialMultiplication(List<int> polynomialA, List<int> polynomialB)
        {
            var product = new int[polynomialA.Count + polynomialB.Count - 1];
            int position = 0;
            for (int i = 0; i < polynomialA.Count; i++)
            {
                for (int j = 0; j < polynomialB.Count; j++)
                {
                    position = i + j;
                    product[position] += polynomialA[i] * polynomialB[j];
                }
            }
            return product;
        }

        static void AddLeadingZeros(List<int> firstNumReversed, List<int> secondNumReversed)
        {
            if (firstNumReversed.Count < secondNumReversed.Count)
            {
                for (int i = 0; i < secondNumReversed.Count - firstNumReversed.Count; i++)
                {
                    firstNumReversed.Add(0);
                }
            }
            else
            {
                for (int i = 0; i < firstNumReversed.Count - secondNumReversed.Count; i++)
                {
                    secondNumReversed.Add(0);
                }
            }
            PolynomialSubstraction(firstNumReversed, secondNumReversed);
        }
    }
}
