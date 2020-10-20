using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> rawElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            rawElements.RemoveAt(0);

            if (rawElements.Count == 0)
            {
                rawElements = null;
            }
            
            ListyIterator<string> listyIterator = new ListyIterator<string>(rawElements);
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        Console.WriteLine(listyIterator.Print());
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
