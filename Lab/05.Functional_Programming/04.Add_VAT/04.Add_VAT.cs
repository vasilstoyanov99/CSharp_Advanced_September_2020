using System;
using System.Linq;

namespace _04.Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] addedVAT = Console.ReadLine().Split(", ").Select(double.Parse).Select(x => x * 1.20).ToArray();

            foreach (var price in addedVAT)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
