using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military_Elite.Contracts
{
    public interface IEngineer
    {
        List<IRepair> repairs { get; }
    }
}
