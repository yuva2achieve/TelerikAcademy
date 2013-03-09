using System;
using System.Linq;

namespace _03.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog[] dogList = new Dog[]
            {
                new Dog("Rex", 13, 'M'),
                new Dog("Lassie", 8, 'F'),
                new Dog("Bethoven", 5, 'M')
            };
            Cat[] catList = new Cat[]
            {
                new Tomcat("Tom", 10),
                new Kitten("Nyan cat", 4),
                new Tomcat("Grumpy cat", 3)
            };
            Frog[] frogList = new Frog[]
            {
                new Frog("First frog", 3,'M'),
                new Frog("Nyan frog", 16,'F'),
                new Frog("Grumpy frog", 7,'M')
            };
            Console.WriteLine(Animal.CalculateAverageAge(dogList));
            Console.WriteLine(Animal.CalculateAverageAge(catList));
            Console.WriteLine(Animal.CalculateAverageAge(frogList));
            dogList[0].MakeSound();
            catList[0].MakeSound();
            frogList[0].MakeSound();
        }
    }
}
