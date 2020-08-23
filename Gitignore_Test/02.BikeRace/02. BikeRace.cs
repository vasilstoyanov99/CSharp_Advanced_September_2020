using System;

namespace _02.BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int Juniors = int.Parse(Console.ReadLine());
            int Seniors = int.Parse(Console.ReadLine());
            string TypeRoute = Console.ReadLine().ToLower();
            int TotalPeole = Seniors + Juniors;
            double SumedTax = 0; 

            if(TypeRoute == "trail")
                SumedTax = (Juniors * 5.50) + (Seniors * 7);
            else if (TypeRoute == "cross-country")
            {
                SumedTax = (Juniors * 8) + (Seniors * 9.50);
                if(TotalPeole >= 50)
                {
                    double Check = SumedTax * 0.25;
                    SumedTax = SumedTax - Check;
                }
            }
            else if (TypeRoute == "downhill")
                SumedTax = (Juniors * 12.25) + (Seniors * 13.75);
            else if (TypeRoute == "road")
                SumedTax = (Juniors * 20) + (Seniors * 21.50);
            double Check2 = SumedTax * 0.05;
            SumedTax = SumedTax - Check2;

            Console.WriteLine($"{SumedTax:f2}");


        }
    }
}
