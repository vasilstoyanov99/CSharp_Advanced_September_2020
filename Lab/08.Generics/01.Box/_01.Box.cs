using System;

namespace BoxOfT
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
