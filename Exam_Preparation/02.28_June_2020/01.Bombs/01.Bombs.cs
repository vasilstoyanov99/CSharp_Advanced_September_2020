using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] effectsInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] casingInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> bombEffects = new Queue<int>(effectsInput);
            Stack<int> bombCasing = new Stack<int>(casingInput);
            int daturaBombsCounter = 0;
            int cherryBombsCounter = 0;
            int smokeDecoyBombsCounter = 0;
            bool areAllNeededBombsMade = false;

            while (bombEffects.Any() && bombCasing.Any())
            {
                if (CheckIfAllNeededTypesOfBombsAreMade(daturaBombsCounter, cherryBombsCounter, smokeDecoyBombsCounter))
                {
                    areAllNeededBombsMade = true;
                    break;
                }

                int firstBombEffect = bombEffects.Dequeue();
                int lastBombCasing = bombCasing.Pop();
                Check(firstBombEffect, lastBombCasing, ref daturaBombsCounter, ref cherryBombsCounter, ref smokeDecoyBombsCounter);
                
            }

            if (areAllNeededBombsMade)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Any())
            {
                Console.WriteLine("Bomb Effects: " + String.Join(", ", bombEffects));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Any())
            {
                Console.WriteLine("Bomb Casings: " + String.Join(", ", bombCasing));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombsCounter}");
            Console.WriteLine($"Datura Bombs: {daturaBombsCounter}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombsCounter}");
        }

        static void Check(int firstBombEffect, int lastBombCasing, ref int daturaBombsCounter,
            ref int cherryBombsCounter, ref int smokeDecoyBombsCounter)
        {
            int totalSum = firstBombEffect + lastBombCasing;

            switch (totalSum)
            {
                case 40:
                    daturaBombsCounter++;
                    break;
                case 60:
                    cherryBombsCounter++;
                    break;
                case 120:
                    smokeDecoyBombsCounter++;
                    break;
                default:
                    lastBombCasing -= 5;
                    Check(firstBombEffect, lastBombCasing, ref daturaBombsCounter, ref cherryBombsCounter, ref smokeDecoyBombsCounter);
                    break;
            }
        }

        static bool CheckIfAllNeededTypesOfBombsAreMade(int daturaBombsCounter,
            int cherryBombsCounter, int smokeDecoyBombsCounter)
        {
            if (daturaBombsCounter >= 3 && cherryBombsCounter >= 3 && smokeDecoyBombsCounter >= 3)
            {
                return true;
            }

            return false;
        }
    }
}
