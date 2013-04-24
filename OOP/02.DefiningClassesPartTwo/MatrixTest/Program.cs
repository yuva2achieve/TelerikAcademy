using System;
using System.Linq;
using Matrix.Common;

namespace MatrixTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Matrix<int> test = new Matrix<int>(4,3);
            //test[0, 0] = 1;
            //test[0, 1] = -1;
            //test[0, 2] = 0;
            //test[1, 0] = 0;
            //test[1, 1] = 2;
            //test[1, 2] = 3;
            //test[2, 0] = 1;
            //test[2, 1] = -3;
            //test[2, 2] = 1;
            //test[3, 0] = 4;
            //test[3, 1] = 0;
            //test[3, 2] = 2;
            //Matrix<int> test2 = new Matrix<int>(3, 2);
            //test2[0, 0] = 2;
            //test2[0, 1] = 1;
            //test2[1, 0] = -1;
            //test2[1, 1] = 0;
            //test2[2, 0] = 3;
            //test2[2, 1] = 1;
            //Matrix<int> res = res = test * test2;
            //Console.WriteLine(test);
            //Console.WriteLine(test2);
            //Console.WriteLine(res);
            Matrix<int> testMatrix = new Matrix<int>(2, 2);
            testMatrix[0, 0] = 1;
            testMatrix[0, 1] = 1;
            testMatrix[1, 0] = 1;
            testMatrix[1, 1] = 1;
            if (testMatrix)
            {
                Console.WriteLine("Positive");
            }
            else
            {
                Console.WriteLine("Negative");
            }
        }
    }
}
