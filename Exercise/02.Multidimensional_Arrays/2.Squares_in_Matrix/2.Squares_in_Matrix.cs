using System;
using System.Linq;

namespace _2.Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = ReadMatrix(data[0], data[1]);
            int equalCharSquareMatrixCounter = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char currChar = matrix[row, col];
                    bool isSquareCellsEqual = currChar == matrix[row, col + 1]
                        && currChar == matrix[row + 1, col] 
                        && currChar == matrix[row + 1, col + 1];

                    if (isSquareCellsEqual)
                    {
                        equalCharSquareMatrixCounter++;
                    }
                }
            }

            Console.WriteLine(equalCharSquareMatrixCounter);
        }
        static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = GetRowData();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
        static char[] GetRowData()
        {
            char[] separetors = new char[] { ' ', ',' };
            return Console.ReadLine().Split(separetors, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
        }
    }
}
