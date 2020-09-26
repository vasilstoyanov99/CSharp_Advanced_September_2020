using System;
using System.Collections.Generic;

namespace _06.Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> carNumbers = new HashSet<string>();

            while (input != "END")
            {
                string[] data = input.Split(", ");

                switch (data[0])
                {
                    case "IN":
                        carNumbers.Add(data[1]);
                        break;
                    case "OUT":
                        carNumbers.Remove(data[1]);
                        break;
                }

                input = Console.ReadLine();
            }

            if (carNumbers.Count > 0)
            {
                foreach (var number in carNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
