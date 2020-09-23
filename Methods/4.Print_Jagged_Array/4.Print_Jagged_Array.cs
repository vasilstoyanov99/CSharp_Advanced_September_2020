using System;

namespace _4.Print_Jagged_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void PrintArray(int[][] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                Console.WriteLine(String.Join(" ", array[row]));
            }
        }
    }
}
