using System;
using System.Collections.Generic;
using System.Linq;

namespace StartUp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IIdentifieable> allIDs = new List<IIdentifieable>();

            while (input != "End")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (data[0].Any(ch => char.IsDigit(ch)))
                {
                    AddRobotData(allIDs, data);
                }
                else
                {
                    AddCitizenData(allIDs, data);
                }

                input = Console.ReadLine();
            }

            string IDsToDetain = Console.ReadLine();

            foreach (var obj in allIDs)
            {
                if (obj.ID.EndsWith(IDsToDetain))
                {
                    Console.WriteLine(obj.ID);
                }
            }
        }

        static void AddRobotData(List<IIdentifieable> allIDs, string[] data)
        {
            Robot robot = new Robot(data[0], data[1]);
            allIDs.Add(robot);
        }

        static void AddCitizenData(List<IIdentifieable> allIDs, string[] data)
        {
            Citizen citizen = new Citizen(data[0], int.Parse(data[1]), data[2]);
            allIDs.Add(citizen);
        }
    }
}
