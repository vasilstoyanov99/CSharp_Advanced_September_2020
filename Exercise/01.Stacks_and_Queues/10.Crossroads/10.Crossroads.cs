using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            var queue = new Queue<string>();
            bool doesACrashHappend = false;
            int passedCarsCount = 0;

            while (input != "END")
            {

                if (input == "green")
                {
                    DoTheGreenLightCycle(queue, greenLightDuration, freeWindowDuration, ref doesACrashHappend, ref passedCarsCount);
                }
                else
                {
                    queue.Enqueue(input);
                }

                if (doesACrashHappend == true)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (!doesACrashHappend)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCarsCount} total cars passed the crossroads.");
            }
        }

        static void DoTheGreenLightCycle(Queue<string> queue, int greenLightDuration, int freeWindowDuration,
            ref bool doesACrashHappend, ref int passedCarsCount)
        {
            string carTemp = String.Empty;
            int charsPassed = 0;
            int nextCharToPassIndex = 0;

            while (greenLightDuration > 0)
            {
                if (queue.Count == 0)
                {
                    return;
                }

                string car = queue.Dequeue();

                if (car.Length < greenLightDuration)
                {
                    greenLightDuration -= car.Length;
                    passedCarsCount++;

                    if (queue.Count == 0)
                    {
                        return;
                    }
                }
                else
                {
                    charsPassed = greenLightDuration;
                    carTemp = car;

                    for (int index = 0; index < car.Length; index++)
                    {
                        if (greenLightDuration <= 0)
                        {
                            nextCharToPassIndex = index;
                            break;
                        }
                        else
                        {
                            greenLightDuration--;
                        }
                    }

                    break;
                }
            }

            int leftCharsToPass = carTemp.Length - charsPassed;

            if (leftCharsToPass < freeWindowDuration)
            {
                freeWindowDuration -= leftCharsToPass;
                passedCarsCount++;
            }
            else
            {
                for (int currChar = nextCharToPassIndex; currChar < carTemp.Length; currChar++)
                {
                    if (freeWindowDuration <= 0)
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{carTemp} was hit at {carTemp[currChar]}.");
                        doesACrashHappend = true;
                        return;
                    }
                    else
                    {
                        freeWindowDuration--;
                    }
                }
            }
        }
    }
}
