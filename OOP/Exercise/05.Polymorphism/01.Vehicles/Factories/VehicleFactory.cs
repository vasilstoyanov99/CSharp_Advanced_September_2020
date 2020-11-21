using System;

using _01.Vehicles.Exception_Messages;
using _01.Vehicles.Models;

namespace _01.Vehicles.Factories
{
    public class VehicleFactory
    {
        Vehicle vehicle;
        public Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            try
            {
                if (type == "Car")
                {
                    vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                }
                else if (type == "Truck")
                {
                    vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                }
                else if (type == "Bus")
                {
                    vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                }
                else
                {
                    throw new InvalidOperationException(OperationMessages.INVALID_VEHICLE_TYPE);
                }
            }
            catch (InvalidOperationException iop)
            {
                Console.WriteLine(iop.Message);
            }

            return vehicle;
        }
    }
}
