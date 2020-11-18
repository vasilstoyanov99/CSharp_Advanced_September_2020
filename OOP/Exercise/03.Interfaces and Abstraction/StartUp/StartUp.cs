using System;
using System.Collections.Generic;
using System.Linq;

using StartUp.Contracts;
using StartUp.Models;

namespace StartUp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IBirthable> allIDs = new List<IBirthable>();

            while (input != "End")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Citizen")
                {
                    AddCitizenData(allIDs, data);
                }
                else if (data[0] == "Pet")
                {
                    AddPetData(allIDs, data);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var obj in allIDs)
            {
                if (obj.Birthday.EndsWith(year))
                {
                    Console.WriteLine(obj.Birthday);
                }
            }
        }

        static void AddPetData(List<IBirthable> allIDs, string[] data)
        {
            string name = data[1];
            string birthday = data[2];
            Pet pet = new Pet(name, birthday);
            allIDs.Add(pet);
        }

        static void AddCitizenData(List<IBirthable> allIDs, string[] data)
        {
            string name = data[1];
            int age = int.Parse(data[2]);
            string id = data[3];
            string birthday = data[4];
            Citizen citizen = new Citizen(name, age, id, birthday);
            allIDs.Add(citizen);
        }
    }
}
