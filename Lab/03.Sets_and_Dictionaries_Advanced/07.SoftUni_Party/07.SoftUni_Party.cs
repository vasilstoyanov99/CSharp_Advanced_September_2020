using System;
using System.Collections.Generic;

namespace _07.SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularGuestsList = new HashSet<string>();
            HashSet<string> VIPGuestsList = new HashSet<string>();
            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (input.Length == 8)
                {
                    if (char.IsDigit(input[0]))
                    {
                        VIPGuestsList.Add(input);
                    }
                    else
                    {
                        regularGuestsList.Add(input);

                    }
                }

                input = Console.ReadLine();
            }

            HashSet<string> regularGuestsWhoDidntCome = new HashSet<string>(regularGuestsList);
            HashSet<string> VIPGuestsWhoDidntCome = new HashSet<string>(VIPGuestsList);
            string secondInput = Console.ReadLine();

            while (secondInput != "END")
            {
                if (secondInput.Length == 8)
                {
                    if (regularGuestsList.Contains(secondInput) || VIPGuestsList.Contains(secondInput))
                    {
                        if (char.IsDigit(secondInput[0]))
                        {
                            VIPGuestsWhoDidntCome.Remove(secondInput);
                        }
                        else
                        {
                            regularGuestsWhoDidntCome.Remove(secondInput);
                        }
                    }
                }

                secondInput = Console.ReadLine();
            }

            int guestsWhoDidntCome = regularGuestsWhoDidntCome.Count + VIPGuestsWhoDidntCome.Count;

            Console.WriteLine(guestsWhoDidntCome);

            foreach (var VIP in VIPGuestsWhoDidntCome)
            {
                Console.WriteLine(VIP);
            }

            foreach (var regular in regularGuestsWhoDidntCome)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
