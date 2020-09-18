using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

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

            int rowIndex = 0;
            int columnIndex = 0;
            int maxSum = int.MinValue;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < columns - 1; col++)
                {
                    int currSum = 0;
                    currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        rowIndex = row;
                        columnIndex = col;
                    }
                }
            }

            StringBuilder result = new StringBuilder();
            result.Append($"{matrix[rowIndex, columnIndex]} {matrix[rowIndex, columnIndex + 1]}");
            result.AppendLine();
            result.Append($"{matrix[rowIndex + 1, columnIndex]} {matrix[rowIndex + 1, columnIndex + 1]}");

            Console.WriteLine(result.ToString());
            Console.WriteLine(maxSum);
        }

        static int[] GetData()
        {
            return Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
