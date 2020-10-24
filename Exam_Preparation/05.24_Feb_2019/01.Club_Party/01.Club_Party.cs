using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

namespace _01.Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            List<string> input  = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            RemoveReservationsWithNoOpenHall(input);
            Stack<string> reservations = new Stack<string>(input);

            while (reservations.Any())
            {
                char currHall = default;
                char.TryParse(reservations.Pop(), out currHall);
                int currHallTotalCapacity = 0;
                List<int> currHallTotalReservations = new List<int>();
                List<char> foundHalls = new List<char>();

                while (reservations.Any())
                {
                    int currReservation = default;

                    if (int.TryParse(reservations.Peek(), out currReservation))
                    {
                        if (currReservation + currHallTotalCapacity <= maxCapacity)
                        {
                            currHallTotalCapacity += currReservation;
                            reservations.Pop();
                            currHallTotalReservations.Add(currReservation);
                        }
                        else
                        {
                            Console.WriteLine($"{currHall} -> {String.Join(", ", currHallTotalReservations)}");

                            if (foundHalls.Count == 0)
                            {
                                reservations.Pop();
                            }
                            else
                            {
                                AddBackFoundHalls(reservations, foundHalls);
                            }
                            
                            break;
                        }
                    }
                    else
                    {
                        foundHalls.Add(char.Parse(reservations.Pop()));
                    }
                }

            }
        }

        static void RemoveReservationsWithNoOpenHall(List<string> reservations)
        {
            for (int i = reservations.Count - 1; i >= 0; i--)
            {
                char currChar = reservations[i][0];

                if (char.IsDigit(currChar))
                {
                    reservations.RemoveAt(i);
                }
                else
                {
                    return;
                }
            }
        }

        static void AddBackFoundHalls(Stack<string> reservations, List<char> foundHalls)
        {
            if (foundHalls.Count > 1)
            {
                foundHalls.Reverse();
            }

            foreach (var hall in foundHalls)
            {
                reservations.Push(hall.ToString());
            }
        }
    }
}
