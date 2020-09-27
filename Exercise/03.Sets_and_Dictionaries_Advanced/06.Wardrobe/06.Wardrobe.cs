using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfINputs = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfINputs; i++)
            {
                string input = Console.ReadLine();
                string[] array = input.Split(" -> ").ToArray();
                string color = array[0];
                List<string> toAdd = array[1].Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());

                    for (int k = 0; k < toAdd.Count; k++)
                    {
                        string dress = toAdd[k];

                        if (!wardrobe[color].ContainsKey(dress))
                        {
                            wardrobe[color].Add(dress, 1);
                        }
                        else
                        {
                            wardrobe[color][dress]++;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < toAdd.Count; j++)
                    {
                        string dress = toAdd[j];

                        if (!wardrobe[color].ContainsKey(dress))
                        {
                            wardrobe[color].Add(dress, 1);
                        }
                        else
                        {
                            wardrobe[color][dress]++;
                        }
                    }
                }
            }

            List<string> toFind = Console.ReadLine().Split().ToList();
            string pieceOfClothToFind = toFind[toFind.Count - 1];
            toFind.Remove(pieceOfClothToFind);
            string colorToFind = String.Join(" ", toFind);
            bool foundColor = false;

            foreach (var currColor in wardrobe)
            {
                Console.WriteLine($"{currColor.Key} clothes:");

                if (currColor.Key == colorToFind)
                {
                    foundColor = true;
                }
                else
                {
                    foundColor = false;
                }

                foreach (var clothes in currColor.Value)
                {
                    if (clothes.Key == pieceOfClothToFind && foundColor)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");

                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
