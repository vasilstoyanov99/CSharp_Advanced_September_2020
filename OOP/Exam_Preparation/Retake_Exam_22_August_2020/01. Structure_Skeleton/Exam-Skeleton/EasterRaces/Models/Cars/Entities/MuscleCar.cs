using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double CUBIC_CENTIMETERS = 5000;
        private const int MIN_HORSE_POWER = 400;
        private const int MAX_HORSE_POWER = 600;
        private int horsePower;

        public MuscleCar
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
