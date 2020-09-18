using System;

namespace _4.Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rowsAndCols, rowsAndCols];

            for (int row = 0; row < rowsAndCols; row++)
            {
                char[] currentRow = GetData();

                for (int col = 0; col < rowsAndCols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            char toFind = char.Parse(Console.ReadLine());
            int rowIndex = 0;
            int columnIndex = 0;
            bool isCharFound = false;

            for (int row = 0; row < rowsAndCols; row++)
            {
                for (int col = 0; col < rowsAndCols; col++)
                {
                    if (matrix[row, col] == toFind)
                    {
                        rowIndex = row;
                        columnIndex = col;
                        isCharFound = true;
                        break;
                    }
                }

                if (isCharFound)
                {
                    break;
                }
            }

            if (isCharFound)
            {
                Console.WriteLine($"({rowIndex}, {columnIndex})");
            }
            else
            {
                Console.WriteLine($"{toFind} does not occur in the matrix ");
            }
        }

        static char[] GetData()
        {
            return Console.ReadLine().ToCharArray();
        }
    }
}
