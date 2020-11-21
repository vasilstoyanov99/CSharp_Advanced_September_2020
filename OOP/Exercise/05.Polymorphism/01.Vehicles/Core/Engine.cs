using System;

using _01.Vehicles.Core.Contracts;
using _01.Vehicles.Exception_Messages;
using _01.Vehicles.Factories;
using _01.Vehicles.Models;

namespace _01.Vehicles.Core
{
    class Engine : IEngine
    {
        private VehicleFactory vehicleFactory;

        public Engine()
        {
            vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {

            Vehicle car = ProcessInputData(vehicleFactory);
            Vehicle truck = ProcessInputData(vehicleFactory);
            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmdType = data[0];
                string vehicleType = data[1];
                double amount = double.Parse(data[2]);

                try
                {
                    if (cmdType == "Drive")
                    {
                        switch (vehicleType)
                        {
                            case "Car":
                                Console.WriteLine(car.Drive(amount));
                                break;
                            case "Truck":
                                Console.WriteLine(truck.Drive(amount));
                                break;
                        }
                    }
                    else if (cmdType == "Refuel")
                    {
                        switch (vehicleType)
                        {
                            case "Car":
                                car.Refuel(amount);
                                break;
                            case "Truck":
                                truck.Refuel(amount);
                                break;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException(OperationMessages.INVALID_COMMAND);
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        static Vehicle ProcessInputData(VehicleFactory vehicleFactory)
        {
            string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string vehicleType = cmdArgs[0];
            double fuelQuantity = double.Parse(cmdArgs[1]);
            double fuelConsumption = double.Parse(cmdArgs[2]);
            return vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption);
        }
    }
}
