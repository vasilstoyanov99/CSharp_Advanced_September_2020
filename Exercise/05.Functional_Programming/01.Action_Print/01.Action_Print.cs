using System;

namespace _01.Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string> printer = Print;

            foreach (var name in names)
            {
                printer(name);
            }
        }

        static void Print(string name)
        {
            Console.WriteLine(name);
        }
    }
}
