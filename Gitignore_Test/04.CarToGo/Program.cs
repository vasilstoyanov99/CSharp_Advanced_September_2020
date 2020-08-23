using System;

namespace _04.CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            double Budget = double.Parse(Console.ReadLine());
            string Season = Console.ReadLine().ToLower();
            if(Budget <= 100)
            {
                if(Season == "summer")
                {
                    double Check = Budget * 0.35;
                    Console.WriteLine($"Economy class");
                    Console.WriteLine($"Cabrio - {Check:f2}");
                }
                else if (Season == "winter")
                {
                    double Check = Budget * 0.65;
                    Console.WriteLine($"Economy class");
                    Console.WriteLine($"Jeep - {Check:f2}");
                }
            }
           else if (Budget > 100 && Budget <= 500)
            {
                if (Season == "summer")
                {
                    double Check = Budget * 0.45;
                    Console.WriteLine($"Compact class");
                    Console.WriteLine($"Cabrio - {Check:f2}");
                }
                else if (Season == "winter")
                {
                    double Check = Budget * 0.80;
                    Console.WriteLine($"Compact class");
                    Console.WriteLine($"Jeep - {Check:f2}");
                }
            }
            else if (Budget > 500)
            {
                double Check = Budget * 0.90;
                Console.WriteLine($"Luxury class");
                Console.WriteLine($"Jeep - {Check:f2}");
            }
        }
    }
}
