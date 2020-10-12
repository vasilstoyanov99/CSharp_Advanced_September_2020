using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var liliesArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rosesArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var lilies = new Queue<int>(liliesArray);
            var roses = new Stack<int>(rosesArray);
            int storedFlowers = 0;
            int doneFlowerWreaths = 0;

            while (roses.Count > 0 || lilies.Count > 0)
            {
                int rose = roses.Pop();
                int lilie = lilies.Dequeue();

                if (rose + lilie == 15)
                {
                    doneFlowerWreaths++;
                }
                else if (rose + lilie > 15)
                {
                    while (rose + lilie > 15)
                    {
                        lilie -= 2;
                    }

                    doneFlowerWreaths++;
                }
                else if (rose + lilie < 15)
                {
                    storedFlowers += rose + lilie;
                }
            }

            int extraWreaths = storedFlowers / 15;
            doneFlowerWreaths += extraWreaths;

            if (doneFlowerWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {doneFlowerWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - doneFlowerWreaths} wreaths more!");
            }
        }

    }
}
