using System;

namespace _07.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();
            string fistName = firstInput[0];
            string lastName = firstInput[1];
            string address = firstInput[2];
            string firstItem = $"{fistName} {lastName}";
            Tuple<string, string> fistTuple = new Tuple<string, string>(firstItem, address);

            string[] secondInput = Console.ReadLine().Split();
            string name = secondInput[0];
            int drinkingBeerCapacity = int.Parse(secondInput[1]);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, drinkingBeerCapacity);

            string[] thirdInput = Console.ReadLine().Split();
            int thisIsInteger = int.Parse(thirdInput[0]);
            double thisIsDouble = double.Parse(thirdInput[1]);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(thisIsInteger, thisIsDouble);

            Console.WriteLine(fistTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
