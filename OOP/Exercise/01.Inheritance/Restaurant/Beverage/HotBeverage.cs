using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class HotBeverage : Beverages
    {
        public HotBeverage(string name, decimal price, double milliliters)
            : base(name, price, milliliters)
        {

        }
    }
}