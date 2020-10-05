using System;
using System.Linq;

namespace _03.Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> delegateFunc = GetTheSmalletsNumber;
            Console.WriteLine(delegateFunc(numbers));
        }

        static int GetTheSmalletsNumber(int[] numbers)
        {
            return numbers.Min();
        }
    }
}
