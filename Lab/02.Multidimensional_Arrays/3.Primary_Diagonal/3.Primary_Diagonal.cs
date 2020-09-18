using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _1.Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rowsAndCols, rowsAndCols];

            for (int row = 0; row < rowsAndCols; row++)
            {
                int[] currentRow = GetData();

                for (int col = 0; col < rowsAndCols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int primaryDiagonalSum = 0;

            for (int index = 0; index < rowsAndCols; index++)
            {
                primaryDiagonalSum += matrix[index, index];
            }

            Console.WriteLine(primaryDiagonalSum);
        }

        static int[] GetData()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
