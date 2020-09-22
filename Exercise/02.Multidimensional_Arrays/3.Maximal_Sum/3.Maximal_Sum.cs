using System;
using System.Linq;

namespace _3.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = data[0];
            int cols = data[1];
            int[,] matrix = ReadMatrix(rows, cols);
            long maxSumOfElements = long.MinValue;
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    long curr3by3MatrixElementsSum = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            curr3by3MatrixElementsSum += (long)(matrix[row + i, col + j]);
                        }
                    }

                    if (curr3by3MatrixElementsSum > maxSumOfElements)
                    {
                        maxSumOfElements = curr3by3MatrixElementsSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSumOfElements}");
            PrintMatrix(matrix, rowIndex, colIndex);

        }

        static void PrintMatrix(int[,] matrix, int rowIndex, int colIndex)
        {
            for (int row = rowIndex; row < rowIndex + 3; row++)
            {
                for (int col = colIndex; col < colIndex + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = GetRowData();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
        static int[] GetRowData()
        {
            char[] separetors = new char[] { ' ', ',' };
            return Console.ReadLine().Split(separetors, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
