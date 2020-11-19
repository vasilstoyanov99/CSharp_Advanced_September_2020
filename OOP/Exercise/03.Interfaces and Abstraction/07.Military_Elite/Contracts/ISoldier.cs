using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military_Elite.Contracts
{
    public interface ISoldier
    {
        public string ID { get; }

        public string FirstName { get; set; }

        public string  LastName { get; set; }
    }
}
