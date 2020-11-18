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
            int linesOfInput = int.Parse(Console.ReadLine());
            var allBuyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < linesOfInput; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 4)
                {
                    AddCitizenData(allBuyers, data);
                }
                else if (data.Length == 3)
                {
                    AddRebelData(allBuyers, data);
                }
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "End")
            {
                string name = secondInput;

                if (allBuyers.ContainsKey(name))
                {
                    allBuyers[name].BuyFood();
                }

                secondInput = Console.ReadLine();
            }

            int totalFoodBought = default;

            foreach (var buyer in allBuyers.Values)
            {
                totalFoodBought += buyer.Food;
            }

            Console.WriteLine(totalFoodBought);
        }

        static void AddRebelData(Dictionary<string, IBuyer> allBuyers, string[] data)
        {
            string name = data[0];
            int age = int.Parse(data[1]);
            string group = data[2];
            Rebel rebel = new Rebel(group, name);
            allBuyers.Add(name, rebel);
        }

        static void AddCitizenData(Dictionary<string, IBuyer> allBuyers, string[] data)
        {
            string name = data[0];
            int age = int.Parse(data[1]);
            string id = data[2];
            string birthday = data[3];
            Citizen citizen = new Citizen(name, age, id, birthday);
            allBuyers.Add(name, citizen);
        }
    }
}
