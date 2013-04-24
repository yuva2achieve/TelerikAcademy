using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIfPointIsWithinACircle
{
    class CheckIfPointIsWithinACircle
    {
        static void Main(string[] args)
        {
            int pointX = 2;
            int pointY = 1;
            int radius = 5;
            if ((pointX*pointX)+(pointY*pointY)<=(radius*radius))
            {
                Console.WriteLine("Given point is within the circle");
            }
            else
            {
                Console.WriteLine("Given point is outside the circle");
            }
        }
    }
}
