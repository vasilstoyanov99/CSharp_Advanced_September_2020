using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Robots.Models
{
    public abstract class Robot : IRobot
    {
        private int _happiness;
        private int _energy;
        private const string DEF_OWNER = "Service";
        private const bool DEF_BOOL = false;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;
            Owner = DEF_OWNER;
            IsBought = DEF_BOOL;
            IsChipped = DEF_BOOL;
            IsChecked = DEF_BOOL;
        }

        public string Name { get; }

        public int Happiness
        {
            get => _happiness;

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                _happiness = value;
            }
        }

        public int Energy
        {
            get => _energy;

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                _energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsBought { get; set; }

        public bool IsChipped { get; set; }

        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return $" Robot type: {GetType().Name} - {Name} - Happiness: {Happiness} - Energy: {Energy}";
        }
    }
}
