using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var lilies = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var roses = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var storedFlowers = new List<int>();
            int doneFlowerWreaths = 0;

            while (true)
            {
                bool shoudBrake = false;

                for (int lilieIndex = lilies.Count - 1; lilieIndex >= 0; lilieIndex--)
                {
                    if (shoudBrake)
                    {
                        shoudBrake = false;
                        break;
                    }

                    for (int roseIndex = 0; roseIndex < roses.Count; roseIndex++)
                    {
                        int rose = roses[roseIndex];
                        int lilie = lilies[lilieIndex];

                        if (rose + lilie == 15)
                        {
                            doneFlowerWreaths++;
                            roses.RemoveAt(roseIndex);
                            lilies.RemoveAt(lilieIndex);
                        }
                        else if (rose + lilie > 15)
                        {
                            lilies[lilieIndex] -= 2;
                        }
                        else
                        {
                            storedFlowers.Add(rose);
                            storedFlowers.Add(lilie);
                            roses.RemoveAt(roseIndex);
                            lilies.RemoveAt(lilieIndex);
                        }

                        shoudBrake = true;
                        break;
                    }
                }

                if (lilies.Count == 0 && roses.Count == 0)
                {
                    break;
                }
            }

            int leftFlowers = storedFlowers.Sum();

            if (leftFlowers >= 15)
            {
                while (leftFlowers >= 15)
                {
                    leftFlowers -= 15;
                    doneFlowerWreaths++;
                }
            }

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
