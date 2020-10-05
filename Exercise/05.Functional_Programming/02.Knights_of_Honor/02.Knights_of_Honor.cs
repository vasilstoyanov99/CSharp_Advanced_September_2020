using System;

namespace _02.Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Func<string, string> sirAdder = AddSir;
            Action<string> printer = Print;

            foreach (var name in names)
            {
                Print(AddSir(name));
            }
        }

        static string AddSir(string name)
        {
            return "Sir " + name;
        }

        static void Print(string result)
        {
            Console.WriteLine(result);
        }
    }
}
