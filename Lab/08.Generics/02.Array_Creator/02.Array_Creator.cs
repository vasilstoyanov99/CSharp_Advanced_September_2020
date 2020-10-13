using _02.Array_Creator;
using System;

namespace _StartUp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] money = ArrayCreator.Create(10, "$$$");
            int[] repeat = ArrayCreator.Create(5, 15);
            Console.WriteLine(String.Join(", ", money));
            Console.WriteLine(String.Join(", ", repeat));
        }
    }
}
