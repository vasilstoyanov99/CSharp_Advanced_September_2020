using System;
using System.Linq;

namespace _01.Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] evenNumbers = Console.ReadLine().Split(", ").Select(x => int.Parse(x)).Where(x => x % 2 == 0).OrderBy(x => x).ToArray();
            Console.WriteLine(String.Join(", ", evenNumbers));
        }
    }
}
