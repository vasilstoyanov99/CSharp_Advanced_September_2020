using System;

namespace _05.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double Budget = double.Parse(Console.ReadLine());
            string Season = Console.ReadLine().ToLower();
            string Location = "";
            string TypeCamp = "";
            double Price = 0.0;
            if (Budget <= 1000)
            {
                TypeCamp = "Camp";
                if(Season == "summer")
                {
                    Location = "Alaska";
                    Price = 0.65;
                }
                else if (Season == "winter")
                {
                    Location = "Morocco";
                    Price = 0.45;
                }
            }
           else if (Budget > 1000 && Budget <= 3000)
            {
                TypeCamp = "Hut";
                if (Season == "summer")
                {
                    Location = "Alaska";
                    Price = 0.80;
                }
                else if (Season == "winter")
                {
                    Location = "Morocco";
                    Price = 0.60;
                }
            }
            else if (Budget > 3000)
            {
                TypeCamp = "Hotel";
                if (Season == "summer")
                {
                    Location = "Alaska";
                    Price = 0.90;
                }
                else if (Season == "winter")
                {
                    Location = "Morocco";
                    Price = 0.90;
                }
            }
            double TotalPrice = Budget * Price;
            Console.WriteLine($"{Location} - {TypeCamp} - {TotalPrice:f2}");
        }
    }
}
