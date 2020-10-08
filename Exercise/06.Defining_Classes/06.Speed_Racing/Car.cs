using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Speed_Racing
{
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public void Drive(double distance)
        {
            double neededFuel = FuelConsumptionPerKilometer * distance;

            if (FuelAmount >= neededFuel)
            {
                FuelAmount -= neededFuel;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
