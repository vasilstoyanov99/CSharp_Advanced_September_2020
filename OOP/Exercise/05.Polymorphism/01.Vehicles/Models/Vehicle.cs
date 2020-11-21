using System;

using _01.Vehicles.Contracts;
using _01.Vehicles.Exception_Messages;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle : IDriveable
    {
        private double _fuelQuantity;
        private const double AMOUNT_TO_INCREASE = 1.4;
        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return _fuelQuantity;
            }
            private set
            {
                if (value > TankCapacity)
                {
                    _fuelQuantity = default;
                }
                else
                {
                    _fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; private set; }

        public int TankCapacity { get; private set; }

        public string Drive(double amount)
        {
            double neededFuelForTheTrip = amount * FuelConsumption;

            if (FuelQuantity < neededFuelForTheTrip)
            {
                throw new InvalidOperationException(String.Format(OperationMessages.NOT_ENOUGH_FUEL,
                    GetType().Name));
            }

            FuelQuantity -= neededFuelForTheTrip;
            return String.Format(OperationMessages.SUCC_TRAVELLED_TRIP, GetType().Name, amount); 
        }

        public virtual void IncreaseFuelConsumption()
        {
            FuelConsumption += AMOUNT_TO_INCREASE;
        }

        public virtual void BringDefaultFuelConsumption()
        {
            FuelConsumption -= AMOUNT_TO_INCREASE;
        }

        public virtual void Refuel(double amount, double lossPercentage)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(OperationMessages.NEGATIVE_FUEL_AMOUNT);
            }
            else if (amount > TankCapacity)
            {
                throw new InvalidOperationException(String.Format(OperationMessages
                    .FUEL_AMOUNT_EXCEEDS_TANK_CAPACITY, amount)); 
            }

            FuelQuantity += (amount * lossPercentage);
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
