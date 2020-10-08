using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace _07.Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] rawData = Console.ReadLine().Split();
                Car car = new Car(rawData);
                allCars.Add(car);
            }

            string command = Console.ReadLine();
            List<Car> sorted = new List<Car>();

            switch (command)
            {
                case "fragile":
                    sorted = allCars.Where(x => x.Cargo.Type == command && x.Tires.Any(x => x.Pressure < 1)).ToList();
                    break;
                case "flamable":
                    sorted = allCars.Where(x => x.Cargo.Type == command && x.Engine.Power > 250).ToList();
                    break;
            }

            foreach (var car in sorted)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
