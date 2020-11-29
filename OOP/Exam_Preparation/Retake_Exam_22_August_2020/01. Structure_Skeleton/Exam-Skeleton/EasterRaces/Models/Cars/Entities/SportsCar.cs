
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double CUBIC_CENTIMETERS = 3000;
        private const int MIN_HORSE_POWER = 250;
        private const int MAX_HORSE_POWER = 450;
        private int horsePower;

        public SportsCar
            (string model, int horsePower)
            : base(model, horsePower)
        {
            CubicCentimeters = CUBIC_CENTIMETERS;
        }

        public override int HorsePower
        {
            get
            {
                return horsePower;
            }
            protected set
            {
                if (!(value >= MIN_HORSE_POWER && value <= MAX_HORSE_POWER))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                horsePower = value;
            }
        }

        public override double CubicCentimeters { get; }
    }
}
