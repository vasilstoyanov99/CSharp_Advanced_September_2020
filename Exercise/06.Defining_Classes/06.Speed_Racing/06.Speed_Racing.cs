using System;
using System.Collections.Generic;

namespace _06.Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            Dictionary<string, Car> allCars = new Dictionary<string, Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumptionPerKilometer = double.Parse(data[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                allCars.Add(model, car);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split();
                string model = command[1];
                double distance = double.Parse(command[2]);
                allCars[model].Drive(distance);
                input = Console.ReadLine();
            }

            foreach (var car in allCars.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
