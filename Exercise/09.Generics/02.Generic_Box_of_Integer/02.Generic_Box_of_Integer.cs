using System;

namespace _02.Generic_Box_of_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                var value = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(value);
                Console.WriteLine(box);
            }
        }
    }
    
}
