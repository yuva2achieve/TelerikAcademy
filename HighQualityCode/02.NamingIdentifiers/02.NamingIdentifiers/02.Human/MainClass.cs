namespace _02.Human
{
    using System;
    using System.Linq;

    public class MainClass
    {
        public enum Sex
        {
            Male,
            Female
        }
        
        public void CreateHuman(int humanAge)
        {
            Human newHuman = new Human();
            newHuman.Age = humanAge;
            if (humanAge % 2 == 0)
            {
                newHuman.Name = "Батката";
                newHuman.Sex = Sex.Male;
            }
            else
            {
                newHuman.Name = "Мацето";
                newHuman.Sex = Sex.Female;
            }
        }

        public class Human
        {
            public Sex Sex { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}
