
using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(sizeOfMatrix, sizeOfMatrix);
            List<int> bombsIndexes = Console.ReadLine().Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (bombsIndexes.Count > 0)
            {
                int bombRow = 0;
                int bombCol = 0;
                bombRow = bombsIndexes[0];
                bombCol = bombsIndexes[1];
                bombsIndexes.RemoveAt(0);
                if (bombsIndexes.Count == 1)
                {
                    bombsIndexes.RemoveAt(0);

                }
                else
                {
                    bombsIndexes.RemoveAt(1);
                }
                int bomb = matrix[bombRow, bombCol];

                if (bomb <= 0)
                {
                    continue;
                }
                else
                {
                    ExplodeTheBomb(matrix, bomb);
                    matrix[bombRow, bombCol] = 0;
                }
            }

            int aliveCellsSum = 0;
            int aliveCellsCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellsSum += matrix[row, col];
                        aliveCellsCount++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
            PrintMatrix(matrix);
        }
        static void PrintMatrix(int[,] matrix)
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
        static void ExplodeTheBomb(int[,] matrix, int bomb)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] -= bomb;
                }
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
