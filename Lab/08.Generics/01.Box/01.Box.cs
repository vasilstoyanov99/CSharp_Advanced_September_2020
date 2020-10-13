using _01.Box;
using System;

namespace _BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            for (int i = 1; i <= 5; i++)
            {
                box.Add(i);
            }

            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Remove());
        }
    }
}
