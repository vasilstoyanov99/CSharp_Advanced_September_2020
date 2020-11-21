using System;

using _01.Vehicles.Contracts;
using _01.Vehicles.Exception_Messages;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle : IDriveable
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }
        public virtual double FuelConsumption { get; private set; }

        public string Drive(double amount)
        {
            double neededFuelForTheTrip = amount * FuelConsumption;

            if (FuelQuantity < neededFuelForTheTrip)
            {
                throw new InvalidOperationException(String.Format(OperationMessages.NOT_ENOUGH_FUEL,
                    GetType().Name));
            }

            FuelQuantity -= neededFuelForTheTrip;
            return String.Format(OperationMessages.FUCC_TRAVELLED_TRIP, GetType().Name, amount); 
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(OperationMessages.NEGATIVE_FUEL_AMOUNT);
            }

            FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
