using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var people = new Queue<string>();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    if (people.Any())
                    {
                        int tempCount = people.Count;

                        for (int i = 0; i < tempCount; i++)
                        {
                            Console.WriteLine(people.Dequeue());
                        }
                    }
                }
                else
                {
                    people.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}
