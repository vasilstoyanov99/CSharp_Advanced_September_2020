using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double tiresPressureSum { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public Car(string make, string model, int year, double fuelQuantity, 
            double fuelConsumption, Engine engine, Tire[] tires)
        {
            Make = make;
            Model = model;
            Year = year;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            Engine = engine;
            Tires = tires;
        }

        public void Drive(double distance)
        {
            double neededFuelForTheTrip = (distance * FuelConsumption) / 100.00;

            if (FuelQuantity - neededFuelForTheTrip > 0)
            {
                FuelQuantity -= neededFuelForTheTrip;
            }
        }

        public string WhoAmI()
        {
            return $"Make: {Make}\nModel: {Model}\nYear: {Year}\nFuel: {FuelQuantity:F2}L";
        } 

        public void GetAllTiresPressureSum()
        {
            tiresPressureSum = 0.00;

            foreach (var currTire in Tires)
            {
                tiresPressureSum += currTire.Pressure;
            }
        }
    }
}
