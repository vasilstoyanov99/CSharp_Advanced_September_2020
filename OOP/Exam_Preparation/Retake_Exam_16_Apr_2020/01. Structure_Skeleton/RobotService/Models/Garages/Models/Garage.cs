using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Robots.Models;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Garages.Models
{
    public class Garage : IGarage
    {
        private const int DEF_CAPACITY = 10;
        private readonly Dictionary<string, IRobot> robots;

        public IReadOnlyDictionary<string, IRobot> Robots => robots;

        public int Capacity  { get; }

        public Garage()
        {
            Capacity = DEF_CAPACITY;
            robots = new Dictionary<string, IRobot>();
        }

        public void Manufacture(IRobot robot)
        {
            if (robots.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!robots.ContainsKey(robotName))
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot soldRobot = robots[robotName];
            soldRobot.Owner = ownerName;
            soldRobot.IsBought = true;
            robots.Remove(robotName);
        }
    }
}
