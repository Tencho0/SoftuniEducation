namespace AquaShop.Models.Decorations
{
    using AquaShop.Models.Decorations.Contracts;
    using System;

    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;

        protected Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }

        public int Comfort
        {
            get
            {
                return comfort;
            }
            private set
            {
                comfort = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                price = value;
            }
        }
    }
}
