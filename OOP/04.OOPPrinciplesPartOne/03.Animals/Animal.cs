using System;
using System.Linq;

namespace _03.Animals
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public char Sex { get; set; }

        public static double CalculateAverageAge(Animal[] animalArray)
        {
            double age = 0;
            int count = 0;
            double average;
            foreach (var animal in animalArray)
            {
                age += animal.Age;
                count++;
            }
            average = age / count;
            return average;
        }
    }
}
