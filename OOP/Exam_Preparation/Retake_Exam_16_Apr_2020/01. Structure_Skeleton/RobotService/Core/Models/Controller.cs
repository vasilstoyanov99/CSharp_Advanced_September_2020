using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Core.Contracts;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Garages.Models;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Procedures.Models;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Robots.Models;
using RobotService.Utilities.Messages;

namespace RobotService.Core.Models
{
    public class Controller : IController
    {
        private Garage garage;
        private IProcedure procedureChip;
        private IProcedure procedureTechCheck;
        private IProcedure procedureRest;
        private IProcedure procedureWork;
        private IProcedure procedureCharge;
        private IProcedure procedurePolish;

        public Controller()
        {
            garage = new Garage();
            procedureChip = new Chip();
            procedureTechCheck = new TechCheck();
            procedureRest = new Rest();
            procedureWork = new Work();
            procedureCharge = new Charge();
            procedurePolish = new Polish();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            // do not use check method here
            IRobot robot = null;

            switch (robotType)
            {
                case "HouseholdRobot":
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case "WalkerRobot":
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
                case "PetRobot":
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                default:
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            garage.Manufacture(robot);
            return String.Format(OutputMessages.RobotManufactured, name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = CheckIfRobotExists(robotName);
            procedureChip.DoService(robot, procedureTime);
            return String.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = CheckIfRobotExists(robotName);
            procedureTechCheck.DoService(robot, procedureTime);
            return String.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = CheckIfRobotExists(robotName);
            procedureRest.DoService(robot, procedureTime);
            return String.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = CheckIfRobotExists(robotName);
            procedureWork.DoService(robot, procedureTime);
            return String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = CheckIfRobotExists(robotName);
            procedureCharge.DoService(robot, procedureTime);
            return String.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = CheckIfRobotExists(robotName);
            procedurePolish.DoService(robot, procedureTime);
            return String.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = CheckIfRobotExists(robotName);
            garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return String.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return String.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string History(string procedureType)
        {
            // do not use check method here
            switch (procedureType)
            {
                case "Chip":
                    return procedureChip.History();
                case "Charge":
                    return procedureCharge.History();
                case "Rest":
                    return procedureRest.History();
                case "Polish":
                    return procedurePolish.History();
                case "Work":
                    return procedureWork.History();
                case "TechCheck":
                    return procedureTechCheck.History();
            }

            return null;
        }

        private IRobot CheckIfRobotExists(string robotName)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            return garage.Robots[robotName];
        }
    }
}
