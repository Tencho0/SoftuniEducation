using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm.Entities.Foods
{
    public class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; }


    }
}
