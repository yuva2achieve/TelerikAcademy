namespace _01.Chef
{
    using System;
    using System.Linq;

    public class Chef
    {
        // Task 1 is in this file
        // Task 2 is in MainClass.cs
        public void Cook()
        {
            Bowl bowl = this.GetBowl();

            Potato potato = this.GetPotato();
            Potato peeledPotato = (Potato)this.Peel(potato);
            Potato cuttedPotato = (Potato)this.Cut(peeledPotato);
            bowl.Add(cuttedPotato);

            Carrot carrot = this.GetCarrot();
            Carrot peeledCarrot = (Carrot)this.Peel(carrot);
            Carrot cuttedCarrot = (Carrot)this.Cut(peeledCarrot);
            bowl.Add(cuttedCarrot);
        }
        
        public void Cook(Vegetable vegetableToCook)
        {
            // Cooking vegetable..
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Vegetable Peel(Vegetable vegetable)
        {
            Vegetable peeledVegetable;
            if (vegetable is Potato)
            {
                peeledVegetable = new Potato();
            }
            else
            {
                peeledVegetable = new Carrot();
            }

            return peeledVegetable;
        }

        private Vegetable Cut(Vegetable vegetable)
        {
            Vegetable cuttedVegetable;
            if (vegetable is Potato)
            {
                cuttedVegetable = new Potato();
            }
            else
            {
                cuttedVegetable = new Carrot();
            }

            return cuttedVegetable;
        }
    }
}
