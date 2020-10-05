using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
            int divider = int.Parse(Console.ReadLine());
            List<int> result = RemoveNumbersThatAreOnlyDivisibleBy(divider, numbers);
            Console.WriteLine(String.Join(" ", result));
        }

        static List<int> RemoveNumbersThatAreOnlyDivisibleBy(int divider, List<int> numbers)
        {
            return numbers.Where(x => x % divider != 0).ToList();
        }
    }
}
