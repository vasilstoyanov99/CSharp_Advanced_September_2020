using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var box = new Stack<int>(clothes);
            int rackCapacity = int.Parse(Console.ReadLine());
            int totalRacksUsed = 0;
            int sum = 0;

            while (box.Any())
            {

                while (box.Any())
                {
                    int temp = box.Peek();

                    if (temp + sum > rackCapacity)
                    {
                        totalRacksUsed++;
                        sum = box.Pop();
                        break;
                    }

                    sum += box.Pop();

                    if (sum == rackCapacity)
                    {
                        totalRacksUsed++;
                        sum = 0;
                        break;
                    }
                }
            }

            if (sum > 0)
            {
                totalRacksUsed++;
            }

            Console.WriteLine(totalRacksUsed);
        }
    }
}
