using System;

namespace _01.MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double Budget = double.Parse(Console.ReadLine());
            string Type = Console.ReadLine().ToLower();
            double People = double.Parse(Console.ReadLine());
            double PercentForTranspot = 0;
            double TicketPrice = 0;
            if (People >= 1 && People <= 4)
                PercentForTranspot += 0.75;
            else if (People >= 5 && People <= 9)
                PercentForTranspot += 0.60;
            else if (People >= 10 && People <= 24)
                PercentForTranspot += 0.50;
            else if (People >= 25 && People <= 49)
                PercentForTranspot += 0.40;
            else if (People >= 50 && People <= 200)
                PercentForTranspot += 0.25;
            if (Type == "vip")
                TicketPrice += 499.99;
            else if (Type == "normal")
                TicketPrice += 249.99;
            double Check = Budget * PercentForTranspot;
            double BudgetAfterTransport = Budget - Check;
            double TicketsTotalPrice =  TicketPrice * People;
                if (TicketsTotalPrice <= BudgetAfterTransport)
            {
                double MoneyLeft = BudgetAfterTransport - TicketsTotalPrice;
                Console.WriteLine($"Yes! You have {MoneyLeft:f2} leva left.");
            }
                else if (TicketsTotalPrice > BudgetAfterTransport)
            {
                double NeededMoney = TicketsTotalPrice - BudgetAfterTransport;
                Console.WriteLine($"Not enough money! You need {NeededMoney:f2} leva.");
            }
        }
    }
}
