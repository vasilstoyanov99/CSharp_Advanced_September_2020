using System;

namespace _01.Generic_Box_of_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                var value = Console.ReadLine();
                Box<string> box = new Box<string>(value);
                Console.WriteLine(box);
            }
        }
    }
}
