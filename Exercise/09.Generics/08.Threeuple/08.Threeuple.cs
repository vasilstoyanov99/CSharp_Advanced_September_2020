using System;
using System.Security.Cryptography;

namespace _08.Threeuple
{
   public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fistName = firstInput[0];
            string lastName = firstInput[1];
            string address = firstInput[2];
            string town = String.Empty;

            if (firstInput.Length == 5)
            {
                town = $"{firstInput[3]} {firstInput[4]}";
            }
            else
            {
                town = firstInput[3];
            }
            
            string firstItem = $"{fistName} {lastName}";
            Threeuple<string, string, string> fistThreeuple = new Threeuple<string, string, string>(firstItem, address, town);

            string[] secondInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = secondInput[0];
            int drankBeer = int.Parse(secondInput[1]);
            string state = secondInput[2];
            bool isDrunk = false;

            if (state == "drunk")
            {
                isDrunk = true;
            }
            

            Threeuple<string, int, bool> secondThreeuple = new Threeuple<string, int, bool>(name, drankBeer, isDrunk);

            string[] thirdInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personName = thirdInput[0];
            double accountBalance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];
            Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(personName, accountBalance, bankName);

            Console.WriteLine(fistThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
