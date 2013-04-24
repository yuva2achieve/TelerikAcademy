using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithinCircleOutsideOfRectangle
{
    class WithinCircleOutsideOfRectangle
    {
        static void Main(string[] args)
        {
            int pointA = 1;
            int pointB = 1;
            int pointX = int.Parse(Console.ReadLine());
            int pointY = int.Parse(Console.ReadLine());
            int radius = 3;
            if (((pointX-pointA)*(pointX-pointA))+((pointY-pointB)*(pointY-pointB))<=(radius*radius))
            {
                if ((pointX<=-1)||(pointX>=6)||(pointY<=1)||(pointY>=2))
                {
                    Console.WriteLine("Given point is within the circle and outside the rectangle!");
                }
                else
                {
                    Console.WriteLine("Given point is within the circle and inside the rectangle!");
                }
            }
            else
            {
                Console.WriteLine("Given point is outside the circle!");
            }
        }
    }
}
