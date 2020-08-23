using System;

namespace _06.TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string Season = Console.ReadLine().ToLower();
            double KMperMonth = double.Parse(Console.ReadLine());
            double PricePerKM = 0.0;
            if (Season == "spring" || Season == "autumn")
            {
                if (KMperMonth <= 5000)
                    PricePerKM += 0.75;
                else if (KMperMonth > 5000 && KMperMonth <= 10000)
                    PricePerKM += 0.95;
            }
            else if (Season == "summer")
            {
                if (KMperMonth <= 5000)
                    PricePerKM += 0.90;
                else if (KMperMonth > 5000 && KMperMonth <= 10000)
                    PricePerKM += 1.10;
            }
            else if (Season == "winter")
            {
                if (KMperMonth <= 5000)
                    PricePerKM += 1.05;
                else if (KMperMonth > 5000 && KMperMonth <= 10000)
                    PricePerKM += 1.25;
            }
            if (KMperMonth > 10000 && KMperMonth <= 20000)
                PricePerKM += 1.45;

            double PriceWTax = KMperMonth * PricePerKM * 4;
            double Check = PriceWTax * 0.10;
            double TotalMoney = PriceWTax - Check;

            Console.WriteLine($"{TotalMoney:f2}");
        }

        
    }
    
}
