using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfCarsThatCanPass = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            var totalCars = new Queue<string>();
            int passedCarsCounter = 0;

            while (input != "end")
            {
                switch (input)
                {
                    case "green":
                        for (int i = 0; i < countOfCarsThatCanPass && totalCars.Any(); i++)
                        {
                            Console.WriteLine($"{totalCars.Dequeue()} passed!");
                            passedCarsCounter++;
                        }
                        break;
                    default:
                        totalCars.Enqueue(input);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{passedCarsCounter} cars passed the crossroads.");
        }
    }
}
