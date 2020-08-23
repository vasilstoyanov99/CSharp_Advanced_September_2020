using System;

namespace _03.Flowers_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumHarizantemi = int.Parse(Console.ReadLine());
            int NumRozi = int.Parse(Console.ReadLine());
            int NumLaleta = int.Parse(Console.ReadLine());
            string Season = Console.ReadLine().ToLower();
            string IsItHoliday = Console.ReadLine().ToLower();
            double HarizantemiPrice = 0.0;
            double RoziPrice = 0.0;
            double LaletaPrice = 0.0;
            int NumFlowers = NumRozi + NumLaleta + NumHarizantemi;

            if(Season == "spring" || Season == "summer")
            {
                HarizantemiPrice += 2.00;
                RoziPrice += 4.10;
                LaletaPrice += 2.50;
            }
            else if(Season == "autumn" || Season == "winter")
            {
                HarizantemiPrice += 3.75;
                RoziPrice += 4.50;
                LaletaPrice += 4.15;
            }
            double HarzantemiTotalPrice = HarizantemiPrice * NumHarizantemi;
            double RoziTotalPrice = RoziPrice * NumRozi;
            double LaletaTotalPrice = LaletaPrice * NumLaleta;
            double TotalFlowerPrice = HarzantemiTotalPrice + LaletaTotalPrice + RoziTotalPrice;
            double BuketPrice1 = TotalFlowerPrice  + 2.0;
            if (IsItHoliday == "y")
            {
                double Check = TotalFlowerPrice * 0.15;
                TotalFlowerPrice = TotalFlowerPrice + Check;
                double BuketPrice = TotalFlowerPrice + 2.0;
                double Check4 = 0;
                if (Season == "spring" && NumLaleta > 7)
                {
                     Check4 += 0.05;
                    
                }
                if (Season == "winter" && NumRozi >= 10)
                {
                     Check4 += 0.10;
                }
               if (NumFlowers > 20)
                {
                    Check4 += 0.20;
                }
               if(Check4 > 0)
                {
                    double Discount = BuketPrice * Check4;
                    BuketPrice -= Discount;
                }
                Console.WriteLine($"{BuketPrice:f2}");
            }
            Console.WriteLine($"{BuketPrice1:f2}");

        }
    }
}
