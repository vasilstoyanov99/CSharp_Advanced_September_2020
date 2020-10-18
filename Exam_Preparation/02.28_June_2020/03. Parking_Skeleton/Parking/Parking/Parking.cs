using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count
        { 
            get
            {
                return allCars.Count;
            } 
        }
        private Dictionary<string, Car> allCars { get; set; }

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            allCars = new Dictionary<string, Car>();
        }

        public void Add(Car car)
        {
            if (allCars.Count <= Capacity)
            {
                allCars.Add(car.Model, car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (allCars.ContainsKey(model))
            {
                if (allCars[model].Manufacturer == manufacturer)
                {
                    allCars.Remove(model);
                    return true;
                }
            }

            return false;
        }

        public Car GetLatestCar()
        {
            if (allCars.Count == 0)
            {
                return null;
            }

            foreach (var car in allCars.Values.OrderByDescending(x => x.Year))
            {
                return car;
            }

            return null;
        }

        public Car GetCar(string manufacturer, string model)
        {
            if (allCars.ContainsKey(model))
            {
                if (allCars[model].Manufacturer == manufacturer)
                {
                    return allCars[model];
                }
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in allCars.Values)
            {
                result.AppendLine(car.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
