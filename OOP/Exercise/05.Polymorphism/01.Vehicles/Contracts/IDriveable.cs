using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Contracts
{
    public interface IDriveable
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; }

        string Drive(double amount);

        void Refuel(double amount);
    }
}
