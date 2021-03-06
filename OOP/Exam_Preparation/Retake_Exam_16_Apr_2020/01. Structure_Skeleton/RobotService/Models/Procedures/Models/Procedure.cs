﻿using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures.Models
{
    public abstract class Procedure : IProcedure
    {
        protected HashSet<IRobot> Robots { get; set; } // TODO: Check if the collection should be a field!

        protected Procedure()
        {
            Robots = new HashSet<IRobot>();
        }

        public string History()
        {
           StringBuilder result = new StringBuilder();
           result.AppendLine($"{GetType().Name}");

           foreach (var robot in Robots)
           {
               result.AppendLine(robot.ToString());
           }

           return result.ToString().TrimEnd();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime  < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
        }
    }
}
