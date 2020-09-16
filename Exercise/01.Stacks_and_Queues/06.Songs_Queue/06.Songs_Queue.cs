using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songsPlaylist = new Queue<string>(Console.ReadLine().Split(", "));
            string input = Console.ReadLine();

            while (songsPlaylist.Any())
            {
                List<string> command = input.Split().ToList();

                switch (command[0])
                {
                    case "Play":
                        songsPlaylist.Dequeue();
                        break;
                    case "Add":
                        command.RemoveAt(0);
                        string song = String.Join(" ", command);

                        if (songsPlaylist.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            songsPlaylist.Enqueue(song);
                        }

                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", songsPlaylist));
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
