using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBoxNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondBoxNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> firstBox = new Queue<int>(firstBoxNumbers);
            Stack<int> secondBox = new Stack<int>(secondBoxNumbers);
            int totalClaimedSum = 0;

            while (firstBox.Any() && secondBox.Any())
            {
                int firstBoxNum = firstBox.Peek();
                int secondBoxNum = secondBox.Peek();
                int totalSum = firstBoxNum + secondBoxNum;

                if (totalSum % 2 == 0) 
                {
                    totalClaimedSum += totalSum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    int lastItem = secondBox.Pop();
                    firstBox.Enqueue(lastItem);
                }
            }

            if (!firstBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (totalClaimedSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {totalClaimedSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {totalClaimedSum}");
            }
        }
    }
}
