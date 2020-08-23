using System;

namespace _07.SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string Season = Console.ReadLine().ToLower();
            string Type = Console.ReadLine().ToLower();
            int StidentsNum = int.Parse(Console.ReadLine());
            int NightsNum = int.Parse(Console.ReadLine());
            double PricePerNight = 0.0;
            string TypeSport = "";
            double TotalPrice = 0.0;

            if(Season == "winter")
            {
                if (Type == "boys")
                {
                    PricePerNight += 9.60;
                    TypeSport = "Judo";
                }
                else if (Type == "girls")
                {
                    PricePerNight += 9.60;
                    TypeSport = "Gymnastics";
                }
                else if (Type == "mixed")
                {
                    PricePerNight += 10.0;
                    TypeSport = "Ski";
                }
            }
         else if (Season == "spring")
            {
                if (Type == "boys")
                {
                    PricePerNight += 7.20;
                    TypeSport = "Tennis";
                }
                else if (Type == "girls")
                {
                    PricePerNight += 7.20;
                    TypeSport = "Athletics";
                }
                else if (Type == "mixed")
                {
                    PricePerNight += 9.50;
                    TypeSport = "Cycling";
                }
            }
            else if (Season == "summer")
            {
                if (Type == "boys")
                {
                    PricePerNight += 15.0;
                    TypeSport = "Football";
                }
                else if (Type == "girls")
                {
                    PricePerNight += 15.0;
                    TypeSport = "Volleyball";
                }
                else if (Type == "mixed")
                {
                    PricePerNight += 20;
                    TypeSport = "Swimming";
                }
            }
            TotalPrice += StidentsNum * NightsNum * PricePerNight;
            if (StidentsNum >= 50)
            {
                double Check = TotalPrice * 0.50;
                TotalPrice -= Check;
            }
            else if (StidentsNum >= 20 && StidentsNum < 50)
            {
                double Check = TotalPrice * 0.15;
                TotalPrice -= Check;
            }
            else if (StidentsNum >= 10 && StidentsNum < 20)
            {
                double Check = TotalPrice * 0.05;
                TotalPrice -= Check;
            }
            Console.WriteLine($"{TypeSport} {TotalPrice:f2} lv.");
        }
    }
}
