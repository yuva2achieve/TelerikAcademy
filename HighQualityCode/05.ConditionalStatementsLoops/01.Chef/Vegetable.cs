namespace _01.Chef
{
    using System;
    using System.Linq;

    public abstract class Vegetable
    {
        private VegetableState state;

        public VegetableState State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }

        public virtual bool HasBeenPeeled()
        {
            bool isPeeled = false;
            if (this.State == VegetableState.Peeled)
            {
                isPeeled = true;
            }

            return isPeeled;
        }

        public virtual bool IsFresh()
        {
            bool isFresh = true;
            if (this.State == VegetableState.Rotten)
            {
                isFresh = false;
            }

            return isFresh;
        }
    }
}
