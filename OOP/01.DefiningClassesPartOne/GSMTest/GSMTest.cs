using System;
using System.Linq;
using MobilePhone.Common;

namespace GSMTest
{
    class GSMTest
    {
        static void Main(string[] args)
        {
            GSM[] phoneArray = new GSM[2];
            phoneArray[0] = new GSM("Asha", "Nokia", "Jorj Ganchev", 120.99d,
                new Battery("Nokia battery", 12d, 10.5d, BatteryType.LiIon),
                new Display(7.5d, 16000000l));
            phoneArray[1] = new GSM("Desire", "HTC", "HTC owner");
            foreach (var phone in phoneArray)
            {
                Console.WriteLine(phone);
            }
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
