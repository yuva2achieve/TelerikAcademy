namespace _01.Chef
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bowl
    {
        private List<Vegetable> ingredients = new List<Vegetable>();

        public void Add(Vegetable ingredient)
        {
            if (ingredient != null) 
            {
                this.ingredients.Add(ingredient);
            }
            else
            {
                throw new ArgumentNullException("Ingredient can't be null");
            }
        }
    }
}
