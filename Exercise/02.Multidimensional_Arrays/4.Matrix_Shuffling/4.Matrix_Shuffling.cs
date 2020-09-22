using System;
using System.Linq;

namespace _4.Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = data[0];
            int cols = data[1];
            string[,] matrix = ReadMatrix(rows, cols);
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] command = input.Split().ToArray();

                if (command.Contains("swap"))
                {
                    if (command.Length - 1 == 4)
                    {
                        int row1 = int.Parse(command[1]);
                        int col1 = int.Parse(command[2]);
                        int row2 = int.Parse(command[3]);
                        int col2 = int.Parse(command[4]);

                        bool areRowAndCol1Valid = (row1 >= 0 && row1 < rows) && (col1 >= 0 && col1 < cols);
                        bool areRowAndCol2Valid = (row2 >= 0 && row2 < rows) && (col2 >= 0 && col2 < cols);

                        if (areRowAndCol1Valid && areRowAndCol2Valid)
                        {
                            string temp = matrix[row1, col1];
                            matrix[row1, col1] = matrix[row2, col2];
                            matrix[row2, col2] = temp;
                            PrintMatrix(matrix);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = GetRowData();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
        static string[] GetRowData()
        {
            char[] separetors = new char[] { ' ', ',' };
            return Console.ReadLine().Split(separetors, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}
