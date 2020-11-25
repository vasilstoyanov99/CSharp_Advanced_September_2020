using System;
using System.Collections.Generic;
using System.Linq;

using _07.Military_Elite.Contracts;
using _07.Military_Elite.Exceptions;
using _07.Military_Elite.Models;


namespace _07.Military_Elite.Core.Models
{
    public class Engine : IEngine
    {
        private ICollection<ISoldier> soldiers;

        public Engine()
        {
            soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            
            while (input != "End")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string soldierType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];
                ISoldier soldier = null;

                switch (soldierType)
                {
                    case "Private":
                        decimal privateSalary = decimal.Parse(cmdArgs[4]);
                        soldier = AddPrivate(id, firstName, lastName, privateSalary);
                        break;
                    case "LieutenantGeneral":
                        decimal lieutenantSalary = decimal.Parse(cmdArgs[4]);
                        soldier = AddLieutenantGeneral(id, firstName, lastName, lieutenantSalary, cmdArgs);
                        break;
                    case "Engineer":
                        decimal engineerSalary = decimal.Parse(cmdArgs[4]);
                        string engineerCorps = cmdArgs[5];

                        try
                        {
                            IEngineer engineer = new Engineer(id, firstName, lastName, engineerSalary, engineerCorps);
                            string[] repairArgs = cmdArgs.Skip(6).ToArray();

                            for (int i = 0; i < repairArgs.Length; i += 2)
                            {
                                string partName = repairArgs[i];
                                int hoursWorked = int.Parse(repairArgs[i + 1]);
                                IRepair repair = new Repair(partName, hoursWorked);
                                engineer.AddRepair(repair);
                            }

                            soldier = engineer;
                        }
                        catch (InvalidCorpsException)
                        {
                            continue;
                        }

                        break;
                    case "Commando":
                        decimal commandoSalary = decimal.Parse(cmdArgs[4]);
                        string commandoCorps = cmdArgs[5];

                        try
                        {
                            ICommando commando = new Commando(id, firstName, lastName, commandoSalary, commandoCorps);
                            string[] missionArgs = cmdArgs.Skip(6).ToArray();

                            for (int i = 0; i < missionArgs.Length; i += 2)
                            {
                                string missionCodeName = missionArgs[i];
                                string missionState = missionArgs[i + 1];

                                try
                                {
                                    IMission mission = new Mission(missionCodeName, missionState);
                                    commando.AddMission(mission);
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }

                            soldier = commando;
                        }
                        catch (InvalidCorpsException)
                        {
                            continue;
                        }

                        break;
                    case "Spy":
                        int codeNumber = int.Parse(cmdArgs[4]);
                        soldier = AddSpy(id, firstName, lastName, codeNumber);
                        break;
                }

                if (soldier != null)
                {
                    soldiers.Add(soldier);
                }
                
                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private ISoldier AddPrivate
            (int id, string firstName, string lastName, decimal salary)
        {
            return new Private(id, firstName, lastName, salary);
        }

        private ISoldier AddLieutenantGeneral
            (int id, string firstName, string lastName, decimal salary, string[] cmdArgs)
        {
            ILieutenantGeneral general =
                            new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (var pid in cmdArgs.Skip(5))
            {
                ISoldier toAdd = soldiers.First(x => x.ID == int.Parse(pid));
                general.AddPrivate(toAdd);
            }

            return general;
        }

        private ISoldier AddSpy
           (int id, string firstName, string lastName, int codeNumber)
        {
            return new Spy(id, firstName, lastName, codeNumber);
        }
    }
}
