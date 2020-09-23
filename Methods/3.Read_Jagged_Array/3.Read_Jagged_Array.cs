using System;
using System.Linq;

namespace _3.Read_Jagged_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] array = FillJaggedArray(rows);
        }
        static int[][] FillJaggedArray(int rows)
        {
            int[][] array = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                array[row] = numbers;
            }

            return array;
        }
    }
}
