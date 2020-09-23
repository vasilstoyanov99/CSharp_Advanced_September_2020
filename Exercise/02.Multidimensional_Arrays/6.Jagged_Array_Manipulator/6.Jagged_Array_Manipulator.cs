using System;
using System.Linq;

namespace _6.Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] array = FillJaggedArray(rows);
            AnalyzeArray(array);
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "Add":
                        AddValue(array, command);
                        break;
                    case "Subtract":
                        SubtractValue(array, command);
                        break;
                }

                input = Console.ReadLine();
            }

            PrintArray(array);
        }

        static void AddValue(double[][] array, string[] command)
        {
            int rowIndex = int.Parse(command[1]);
            int columnIndex = int.Parse(command[2]);
            bool areIndexesValid = (rowIndex >= 0 && rowIndex < array.GetLength(0)
                && (columnIndex >= 0 && columnIndex < array[rowIndex].Length));

            if (areIndexesValid)
            {
                int value = int.Parse(command[3]);
                array[rowIndex][columnIndex] += value;
            }
           
        }

        static void SubtractValue(double[][] array, string[] command)
        {
            int rowIndex = int.Parse(command[1]);
            int columnIndex = int.Parse(command[2]);
            bool areIndexesValid = (rowIndex >= 0 && rowIndex < array.GetLength(0)
                && (columnIndex >= 0 && columnIndex < array[rowIndex].Length));

            if (areIndexesValid)
            {
                int value = int.Parse(command[3]);
                array[rowIndex][columnIndex] -= value;
            }
        }

        static double[][] FillJaggedArray(int rows)
        {
            double[][] array = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
                array[row] = numbers;
            }

            return array;
        }

        static void AnalyzeArray(double[][] array)
        {
            for (int row = 0; row < array.GetLength(0) - 1; row++)
            {
                if (array[row].Length == array[row + 1].Length)
                {
                    for (int row1Element = 0; row1Element < array[row].Length; row1Element++)
                    {
                        array[row][row1Element] *= 2.00;
                    }

                    for (int row2Element = 0; row2Element < array[row].Length; row2Element++)
                    {
                        array[row + 1][row2Element] *= 2.00;
                    }
                }
                else
                {
                    for (int row1Element = 0; row1Element < array[row].Length; row1Element++)
                    {
                        array[row][row1Element] /= 2.00;
                    }

                    for (int row2Element = 0; row2Element < array[row + 1].Length; row2Element++)
                    {
                        array[row + 1][row2Element] /= 2.00;
                    }
                }
            }
        }

        static void PrintArray(double[][] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                Console.WriteLine(String.Join(" ", array[row]));
            }
        }
    }
}
