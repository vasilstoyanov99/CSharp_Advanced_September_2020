using System;
using System.Collections.Generic;

namespace _7.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            var players = new Queue<string>(names);
            int toss = int.Parse(Console.ReadLine());
            int currentToss = 1;

            while (players.Count > 1)
            {
                string currentPlayer = players.Dequeue();

                if (currentToss == toss)
                {
                    Console.WriteLine($"Removed {currentPlayer}");
                    currentToss = 1;
                }
                else
                {
                    currentToss++;
                    players.Enqueue(currentPlayer);
                }
            }

            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
