using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _1.Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = data[0];
            int columns = data[1];
            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = GetData();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            long sum = 0;

            foreach (var number in matrix)
            {
                sum += number;
            }

            Console.WriteLine(rows);
            Console.WriteLine(columns);
            Console.WriteLine(sum);
        }

        static int[] GetData()
        {
            return Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
