using System;
using System.Data;
using System.Linq;

namespace _6.Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] array = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] toInsert = Console.ReadLine().Split().Select(int.Parse).ToArray();
                array[row] = toInsert;
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commands = input.Split();

                switch (commands[0])
                {
                    case "Add":
                        IncreaseValue(commands, array);
                        break;
                    case "Subtract":
                        DecreaseValue(commands, array);
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var item in array)
            {
                Console.WriteLine(String.Join(" ", item));
            }
        }

        static void IncreaseValue(string[] commands, int[][] array)
        {
            int rowIndex = int.Parse(commands[1]);
            int columnIndex = int.Parse(commands[2]);
            int value = int.Parse(commands[3]);
            bool areIndexesInCorrect = rowIndex < 0 || rowIndex >= array.GetLength(0) || columnIndex < 0 || columnIndex >= array[rowIndex].Length; 

            if (areIndexesInCorrect)
            {
                Console.WriteLine("Invalid coordinates");
            }
            else
            {
                array[rowIndex][columnIndex] += value;
            }
        }

        static void DecreaseValue(string[] commands, int[][] array)
        {
            int rowIndex = int.Parse(commands[1]);
            int columnIndex = int.Parse(commands[2]);
            int value = int.Parse(commands[3]);
            bool areIndexesInCorrect = rowIndex < 0 || rowIndex >= array.GetLength(0) || columnIndex < 0 || columnIndex >= array[rowIndex].Length;

            if (areIndexesInCorrect)
            {
                Console.WriteLine("Invalid coordinates");
            }
            else
            {
                array[rowIndex][columnIndex] -= value;
            }
        }
    }
}
