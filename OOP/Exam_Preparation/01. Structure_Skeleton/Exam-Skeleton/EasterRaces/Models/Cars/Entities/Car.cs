using System;

using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;

        public Car
            (string model, int horsePower)
        {
            Model = model;
            HorsePower = horsePower;
        }

        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) | value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }

                model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }

        public abstract double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            double result = CubicCentimeters / HorsePower * laps;
            return result;
        }
    }
}
