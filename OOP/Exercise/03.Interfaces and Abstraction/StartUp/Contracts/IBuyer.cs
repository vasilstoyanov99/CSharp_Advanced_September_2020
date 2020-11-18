using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp.Contracts
{
    public interface IBuyer 
    {
        public int Food { get; }

        void BuyFood();
    }
}
