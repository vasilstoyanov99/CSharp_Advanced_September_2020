using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverages : Product
    {
        public double Milliliters { get; private set; }

        public Beverages(string name, decimal price, double milliliters)
            : base(name, price)
        {
            Milliliters = milliliters;
        }
    }
}