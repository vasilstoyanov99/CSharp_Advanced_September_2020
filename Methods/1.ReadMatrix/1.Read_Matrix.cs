using System;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _1.ReadMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix(3, 6);
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
