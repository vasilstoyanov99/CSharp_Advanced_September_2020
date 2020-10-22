using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace _01.Santas_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] materialsArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] magicValuesArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> materials = new Stack<int>(materialsArray);
            Queue<int> magicValues = new Queue<int>(magicValuesArray);
            Dictionary<string, int> craftedPresents = new Dictionary<string, int>();
            craftedPresents.Add("Doll", 0);
            craftedPresents.Add("Train", 0);
            craftedPresents.Add("Teddy bear", 0);
            craftedPresents.Add("Bicycle", 0);

            while (materials.Any() && magicValues.Any())
            {
                int currMaterial = materials.Peek();
                int currMagicValue = magicValues.Peek();
                int totalMagicLevel = currMaterial * currMagicValue;

                if (currMaterial == 0 || currMagicValue == 0)
                {
                    if (currMaterial == 0)
                    {
                        materials.Pop();
                    }
                    else if (currMagicValue == 0)
                    {
                        magicValues.Dequeue();
                    }

                    continue;
                }

                switch (totalMagicLevel)
                {
                    case 150:
                        craftedPresents["Doll"]++;
                        RemoveItems(materials, magicValues);
                        break;
                    case 250:
                        craftedPresents["Train"]++;
                        RemoveItems(materials, magicValues);
                        break;
                    case 300:
                        craftedPresents["Teddy bear"]++;
                        RemoveItems(materials, magicValues);
                        break;
                    case 400:
                        craftedPresents["Bicycle"]++;
                        RemoveItems(materials, magicValues);
                        break;
                    default:
                        if (totalMagicLevel < 0)
                        {
                            int totalMagicLevelSumed = currMaterial + currMagicValue;
                            RemoveItems(materials, magicValues);
                            materials.Push(totalMagicLevelSumed);
                        }
                        else if (totalMagicLevel == 0)
                        {
                            if (currMaterial == 0)
                            {
                                materials.Pop();
                            }
                            else if (currMagicValue == 0)
                            {
                                magicValues.Dequeue();
                            }
                        }
                        else
                        {
                            RemoveItems(materials, magicValues);
                            currMaterial += 15;
                            materials.Push(currMaterial);
                        }
                        break;
                }
            }

            bool areNeededPresentsCrafted = false;

            if ((craftedPresents["Doll"] > 0 && craftedPresents["Train"] > 0)
                || (craftedPresents["Teddy bear"] > 0 && craftedPresents["Bicycle"] > 0))
            {
                areNeededPresentsCrafted = true;
            }

            if (areNeededPresentsCrafted)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Any() || magicValues.Any())
            {
                if (materials.Any())
                {
                    var sortedMaterials = materials.Where(x => x > 0).ToList();

                    if (sortedMaterials.Count > 0)
                    {
                        Console.WriteLine($"Materials left: {String.Join(", ", materials)}");
                    }          
                }

                if (magicValues.Any())
                {
                    var sortedMagicValues = magicValues.Where(x => x > 0).ToList();

                    if (sortedMagicValues.Count > 0)
                    {
                        Console.WriteLine($"Magic left: {String.Join(", ", sortedMagicValues)}");
                    }
                }
            }

            var sorted = craftedPresents.Where(x => x.Value > 0).OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var present in sorted)
            {
                Console.WriteLine($"{present.Key}: {present.Value}");
            }
        }

        static void RemoveItems(Stack<int> materials, Queue<int> magicValues)
        {
            materials.Pop();
            magicValues.Dequeue();
        }
    }
}
