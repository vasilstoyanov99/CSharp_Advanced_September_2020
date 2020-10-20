using System;

namespace _1.Read_Char_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixDimensions = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(matrixDimensions, matrixDimensions);
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
            return Console.ReadLine().Trim().ToCharArray();
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
