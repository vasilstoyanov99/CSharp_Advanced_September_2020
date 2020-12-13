using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods.Models
{
    public class Cake : BakedFood
    {
        private const int InitialBreadPortion = 245;

        public Cake(string name, decimal price)
            : base(name, InitialBreadPortion, price)
        {
        }
    }
}
