using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> allTires = new List<Tire[]>();
            List<Engine> allEngines = new List<Engine>();
            List<Car> allCars = new List<Car>();

            GetAllTires(allTires);
            GetAllEngines(allEngines);
            GetAllCars(allCars, allTires, allEngines);

            List<Car> sortedCars = allCars.Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 330).ToList();

            foreach (var car in sortedCars)
            {
                car.GetAllTiresPressureSum();
            }

            sortedCars = sortedCars.Where(x => x.tiresPressureSum > 9 && x.tiresPressureSum < 10).ToList();

            foreach (var car in sortedCars)
            {
                car.Drive(20);
            }

            foreach (var specialCar in sortedCars)
            {
                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }

        static void GetAllEngines(List<Engine> allEngines)
        {
            string input = Console.ReadLine();

            while (input != "Engines done")
            {
                string[] data = input.Split();
                int horsePower = int.Parse(data[0]);
                double cubicCapacity = double.Parse(data[1]);
                Engine newEngine = new Engine(horsePower, cubicCapacity);
                allEngines.Add(newEngine);
                input = Console.ReadLine();
            }
        }

        static void GetAllTires(List<Tire[]> allTires)
        {
            string input = Console.ReadLine();

            while (input != "No more tires")
            {
                List<string> data = input.Split().ToList();
                GetAllTiresData(allTires, data);
                input = Console.ReadLine();
            }
        }

        static void GetAllTiresData(List<Tire[]> allTires, List<string> data)
        {
            Tire[] currTires = new Tire[data.Count / 2];
            int index = 0;

            while (data.Count > 0)
            {
                int year = int.Parse(data[0]);
                double pressure = double.Parse(data[1]);
                Tire newTire = new Tire(year, pressure);
                currTires[index] = newTire;
                data.RemoveRange(0, 2);
                index++;
            }

            allTires.Add(currTires);
        }

        static void GetAllCars(List<Car> allCars, List<Tire[]> allTires, List<Engine> allEngines)
        {
            string input = Console.ReadLine();

            while (input != "Show special")
            {
                string[] data = input.Split();
                string make = data[0];
                string model = data[1];
                int year = int.Parse(data[2]);
                int fuelQuantity = int.Parse(data[3]);
                int fuelConsumption = int.Parse(data[4]);
                int engineIndex = int.Parse(data[5]);
                int tireIndex = int.Parse(data[5]);
                Car newCar = new Car(make, model, year, fuelQuantity, fuelConsumption, allEngines[engineIndex], allTires[tireIndex]);
                allCars.Add(newCar);
                input = Console.ReadLine();
            }
        } 
    }
}
