using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gardenDimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = gardenDimensions[0];
            int cols = gardenDimensions[1];
            int[,] garden = new int[rows, cols];
            string input = Console.ReadLine();
            Dictionary<int, List<int>> plantedFlowersPositions = new Dictionary<int, List<int>>();
            int counter = -1;

            while (input != "Bloom Bloom Plow")
            {
                int[] indexes = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
                int row = indexes[0];
                int col = indexes[1];

                if (CheckIfIndexesAreValid(row, col, garden.GetLength(0), garden.GetLength(1)))
                {
                    counter++;
                    var positions = new List<int>(indexes);
                    plantedFlowersPositions.Add(counter, positions);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                input = Console.ReadLine();
            }

            foreach (var flowerPosition in plantedFlowersPositions.Values)
            {
                BloomFlower(flowerPosition, garden);
            }

            PrintMatrix(garden);
        }

        static bool CheckIfIndexesAreValid(int row, int col, int gardenRowLength, int gardenColLength)
        {
            if ((row >= 0 && row < gardenRowLength) && (col >= 0 && col < gardenColLength))
            {
                return true;
            }

            return false;
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

        static void BloomFlower(List<int> flowerPosition, int[,] garden)
        {
            int flowerRow = flowerPosition[0];
            int flowerCol = flowerPosition[1];

            for (int col = 0; col < garden.GetLength(1); col++) // add to row
            {
                garden[flowerRow, col]++;
            }

            for (int row = 0; row < garden.GetLength(0); row++) // add to col
            {
                if (row == flowerCol)
                {
                    continue;
                }
                garden[row, flowerCol]++;
            }
        }
    }
}
