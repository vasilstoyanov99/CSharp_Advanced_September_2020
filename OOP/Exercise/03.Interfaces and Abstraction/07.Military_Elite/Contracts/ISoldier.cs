using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military_Elite.Contracts
{
    public interface ISoldier
    {
        public int ID { get; }

        public string FirstName { get; }

        public string  LastName { get; }
    }
}
