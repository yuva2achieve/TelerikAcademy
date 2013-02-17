using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.AddPolynomials
{
    class AddPolynomials
    {
        static void Main(string[] args)
        {
            //Polynomial coefficients are entered in reversed order
            var firstPolynomial = new List<int> {-3, 1, 3};
            var secondPolynomial = new List<int> { -1, 1, 5, 3 };
            var polynomialSum = new List<int>(GetPolynomialSum(firstPolynomial, secondPolynomial));
            for (int i = polynomialSum.Count - 1; i >= 0; i--)
            {
                Console.Write("{0}x^{1} ", polynomialSum[i], i);
            }
        }

        static List<int> GetPolynomialSum(List<int> polynomialA, List<int> polynomialB)
        {
            List<int> sum = new List<int>();
            if (polynomialA.Count != polynomialB.Count)
            {
                AddLeadingZeros(polynomialA, polynomialB);
            }
            for (int i = 0; i < polynomialA.Count; i++)
            {
                sum.Add(polynomialA[i] + polynomialB[i]);
            }
            return sum;
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
            GetPolynomialSum(firstNumReversed, secondNumReversed);
        }
    }
}
