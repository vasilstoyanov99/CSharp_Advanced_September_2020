using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _08.Car_Salesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> allEngines = new Dictionary<string, Engine>();
            List<Car> allCars = new List<Car>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                AddNewEngine(data, allEngines);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                AddNewCar(data, allCars, allEngines);
            }

            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");

                if (car.Engine.Displacement == int.MinValue)
                {
                    Console.WriteLine($"    Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }

                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");

                if (car.Weight == int.MinValue)
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                else
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }

                Console.WriteLine($"  Color: {car.Color}");
            }
        }

        static void AddNewEngine(string[] data, Dictionary<string, Engine> allEngines)
        {
            string model = data[0];
            int power = int.Parse(data[1]);
            int displacement = int.MinValue;
            string efficiency = "n/a";

            if (data.Length >= 3)
            {
                if (char.IsDigit(data[2][0]))
                {
                    displacement = int.Parse(data[2]);
                }
                else
                {
                    efficiency = data[2];
                }
                
                if (data.Length == 4)
                {
                    efficiency = data[3];
                }
            }

            Engine engine = new Engine(model, power, displacement, efficiency);
            allEngines.Add(model, engine);
        }

        static void AddNewCar(string[] data, List<Car> allCars, Dictionary<string, Engine> allEngines)
        {
            string model = data[0];
            string engineModel = data[1];
            int weight = int.MinValue;
            string color = "n/a";

            if (data.Length >= 3)
            {
                if (char.IsDigit(data[2][0]))
                {
                    weight = int.Parse(data[2]);
                }
                else
                {
                    color = data[2];
                }

                if (data.Length == 4)
                {
                    color = data[3];
                }
            }

            Car car = new Car(model, allEngines[engineModel], weight, color);
            allCars.Add( car);
        }
    }
}
