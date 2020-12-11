using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Guns.Models
{
    public abstract class Gun : IGun
    {
        private string _name;
        private int _bulletsCount;

        protected Gun(string name, int bulletsCount)
        {
            Name = name;
            BulletsCount = bulletsCount;
        }

        public string Name
        {
            get => _name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                _name = value; 
            }
        }

        public int BulletsCount
        {
            get => _bulletsCount;

            protected set // TODO: Check if set should be private
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }

                _bulletsCount = value;
            }
        }

        public abstract int Fire();
    }
}
