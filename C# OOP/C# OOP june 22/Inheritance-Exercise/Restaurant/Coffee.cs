using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, decimal price, double milliliters) 
            : base(name, 3.50m, 50)
        {
        }
        public double Caffeine { get; set; }
    }
}
