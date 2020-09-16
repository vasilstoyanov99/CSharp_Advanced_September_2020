using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int queueElements = data[0];
            var queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).Take(queueElements));

            if (queue.Count <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            int countOfElementsToPop = data[1];

            if (queue.Count >= countOfElementsToPop)
            {
                for (int i = 0; i < countOfElementsToPop; i++)
                {
                    queue.Dequeue();
                }

                if (queue.Count <= 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            int numberToSearch = data[2];
            bool isNumberFound = false;

            foreach (var number in queue)
            {
                if (number == numberToSearch)
                {
                    Console.WriteLine("true");
                    isNumberFound = true;
                    break;
                }
            }

            if (!isNumberFound)
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
