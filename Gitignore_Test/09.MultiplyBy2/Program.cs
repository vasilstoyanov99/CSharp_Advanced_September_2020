using System;

namespace _09.MultiplyBy2
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            while (num >= 0)
            {

                    double Result = num * 2.0;
                    Console.WriteLine($"Result: {Result:f2}");
                    num = double.Parse(Console.ReadLine());
            }
            while (num < 0)
            {
                Console.WriteLine("Negative number!");
                num = Math.Abs(num);
            }
        }
    }
}
