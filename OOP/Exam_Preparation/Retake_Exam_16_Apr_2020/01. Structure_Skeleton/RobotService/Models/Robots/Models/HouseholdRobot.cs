using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots.Models
{
    public class HouseholdRobot : Robot
    {
        public HouseholdRobot(string name, int energy, int happiness, int procedureTime)
            : base(name, energy, happiness, procedureTime)
        {
        }
    }
}
