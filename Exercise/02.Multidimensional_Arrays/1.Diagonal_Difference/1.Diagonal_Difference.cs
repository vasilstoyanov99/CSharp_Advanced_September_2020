using System;
using System.Linq;

namespace _1.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(rowsAndCols, rowsAndCols);
            int d1Sum = 0;
            int d2Sum = 0;

            for (int row = 0; row < rowsAndCols; row++)
            {
                for (int col = 0; col < rowsAndCols; col++)
                {
                    if (row == col)
                    {
                        int currNumber = matrix[row, col];
                        d1Sum += currNumber;
                    }
                    if (row == rowsAndCols - col - 1)
                    {
                        int currNumber = matrix[row, col];
                        d2Sum += currNumber;
                    }
                }
            }

            int difference = Math.Abs(d1Sum - d2Sum);
            Console.WriteLine(difference);
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
