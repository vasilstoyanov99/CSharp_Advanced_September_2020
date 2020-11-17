using System;

using _03._Telephony.Exceptions;
using _03._Telephony.Model;

namespace _03._Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }
                    else if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException ine)
                {
                    Console.WriteLine(ine.Message);
                }
            }

            foreach (var url in sites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidURLException iurle)
                {
                    Console.WriteLine(iurle.Message);
                }
            }
        }
    }
}
