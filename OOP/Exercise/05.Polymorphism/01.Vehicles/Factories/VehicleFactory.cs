using System;

using _01.Vehicles.Exception_Messages;
using _01.Vehicles.Models;

namespace _01.Vehicles.Factories
{
    public class VehicleFactory
    {
        Vehicle vehicle;
        public Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            try
            {
                if (type == "Car")
                {
                    vehicle = new Car(fuelQuantity, fuelConsumption);
                }
                else if (type == "Truck")
                {
                    vehicle = new Truck(fuelQuantity, fuelConsumption);
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
