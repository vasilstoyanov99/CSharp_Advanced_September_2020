using System;

namespace _7.Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[rows][];
            pascalTriangle[0] = new long[1];
            pascalTriangle[0][0] = 1;

            if (rows >= 2)
            {
                pascalTriangle[1] = new long[] { 1, 1 };
            }

            for (int row = 2; row < rows; row++)
            {
                pascalTriangle[row] = new long[row + 1];
                pascalTriangle[row][0] = 1;
                pascalTriangle[row][row] = 1;

                int index = 0;

                for (int i = row - 1; i > 0; i--)
                {
                    long sum = pascalTriangle[row - 1][index] + pascalTriangle[row - 1][index + 1];
                    pascalTriangle[row][index + 1] = sum;
                    index++;
                }
            }

            for (int row = 0; row < pascalTriangle.Length; row++)
            {
                int currColLenght = pascalTriangle[row].Length;

                for (int col = 0; col <currColLenght ; col++)
                {
                    Console.Write(pascalTriangle[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
