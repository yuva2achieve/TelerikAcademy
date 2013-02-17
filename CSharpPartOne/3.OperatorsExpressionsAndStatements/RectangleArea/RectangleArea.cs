using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleArea
{
    class RectangleArea
    {
        static void Main(string[] args)
        {
            double height = 15.0d;
            double width = 37.5d;
            double area = (height * width);
            Console.WriteLine("The area of rectangle with given height:{0} and width:{1} is {2}", height, width, area);
        }
    }
}