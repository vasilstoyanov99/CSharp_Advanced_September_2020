using System;
using System.Linq;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixDimensions = int.Parse(Console.ReadLine());
            char[,] beeTerritory = ReadMatrix(matrixDimensions, matrixDimensions);
            bool isBeeOutOfTheMatrix = false; 
            string input = Console.ReadLine();
            var beeLocation = FindBee(beeTerritory);
            int beeOldRowIndex = beeLocation.Item1;
            int beeOldColIndex = beeLocation.Item2;
            int beeRowIndex = beeLocation.Item1;
            int beeColIndex = beeLocation.Item2;
            int pollinatedFlowers = 0;

            while (input != "End")
            {

                switch (input)
                {
                    case "up":
                        isBeeOutOfTheMatrix = MoveUp(beeTerritory, ref beeRowIndex, ref pollinatedFlowers, beeColIndex);
                        break;
                    case "down":
                        isBeeOutOfTheMatrix = MoveDown(beeTerritory, ref beeRowIndex, ref pollinatedFlowers, beeColIndex);
                        break;
                    case "left":
                        isBeeOutOfTheMatrix = MoveToLeft(beeTerritory, beeRowIndex, ref beeColIndex, ref pollinatedFlowers);
                        break;
                    case "right":
                        isBeeOutOfTheMatrix = MoveToRight(beeTerritory, beeRowIndex, ref beeColIndex, ref pollinatedFlowers);
                        break;
                }

                if (isBeeOutOfTheMatrix)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                input = Console.ReadLine();
            }

            if (pollinatedFlowers >= 5)
            {
                beeTerritory[beeOldRowIndex, beeOldColIndex] = '.';
                beeTerritory[beeRowIndex, beeColIndex] = 'B';
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                beeTerritory[beeOldRowIndex, beeOldColIndex] = '.';
                if (isBeeOutOfTheMatrix)
                {
                    beeTerritory[beeOldRowIndex, beeOldColIndex] = '.';
                }
                else
                {
                    beeTerritory[beeRowIndex, beeColIndex] = 'B';
                }
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

            PrintMatrix(beeTerritory);
        }

        static bool MoveUp(char[,] beeTerritory, ref int beeRowIndex, ref int pollinatedFlowers, int beeColIndex)
        {
            beeRowIndex--;

            if (beeRowIndex < 0)
            {
                return true;
            }
            else
            {
                char landingChar = beeTerritory[beeRowIndex, beeColIndex];

                if (landingChar == 'f')
                {
                    beeTerritory[beeRowIndex, beeColIndex] = '.';
                    pollinatedFlowers++;
                }
                else if (landingChar == 'O')
                {
                    beeTerritory[beeRowIndex, beeColIndex] = '.';
                    MoveUp(beeTerritory, ref beeRowIndex, ref pollinatedFlowers, beeColIndex);
                }
            }

            return false;
        }

        static bool MoveDown(char[,] beeTerritory, ref int beeRowIndex, ref int pollinatedFlowers, int beeColIndex)
        {
            beeRowIndex++;

            if (beeRowIndex >= beeTerritory.GetLength(0))
            {
                return true;
            }
            else
            {
                char landingChar = beeTerritory[beeRowIndex, beeColIndex];

                if (landingChar == 'f')
                {
                    beeTerritory[beeRowIndex, beeColIndex] = '.';
                    pollinatedFlowers++;
                }
                else if (landingChar == 'O')
                {
                    beeTerritory[beeRowIndex, beeColIndex] = '.';
                    MoveDown(beeTerritory, ref beeRowIndex, ref pollinatedFlowers, beeColIndex);
                }
            }

            return false;
        }

        static bool MoveToRight(char[,] beeTerritory, int beeRowIndex, ref int beeColIndex, ref int pollinatedFlowers)
        {
            beeColIndex++;

            if (beeColIndex >= beeTerritory.GetLength(0))
            {
                return true;
            }
            else
            {
                char landingChar = beeTerritory[beeRowIndex, beeColIndex];

                if (landingChar == 'f')
                {
                    beeTerritory[beeRowIndex, beeColIndex] = '.';
                    pollinatedFlowers++;
                }
                else if (landingChar == 'O')
                {
                    beeTerritory[beeRowIndex, beeColIndex] = '.';
                    MoveToRight(beeTerritory, beeRowIndex, ref beeColIndex, ref pollinatedFlowers);
                }
            }

            return false;
        }

        static bool MoveToLeft(char[,] beeTerritory, int beeRowIndex, ref int beeColIndex, ref int pollinatedFlowers)
        {
            beeColIndex--;

            if (beeColIndex < 0)
            {
                return true;
            }
            else
            {
                char landingChar = beeTerritory[beeRowIndex, beeColIndex];

                if (landingChar == 'f')
                {
                    beeTerritory[beeRowIndex, beeColIndex] = '.';
                    pollinatedFlowers++;
                }
                else if (landingChar == 'O')
                {
                    beeTerritory[beeRowIndex, beeColIndex] = '.';
                    MoveToLeft(beeTerritory, beeRowIndex, ref beeColIndex, ref pollinatedFlowers);
                }
            }

            return false;
        }

        static Tuple<int, int> FindBee(char[,] beeTerritory)
        {
            for (int row = 0; row < beeTerritory.GetLength(0); row++)
            {
                for (int col = 0; col < beeTerritory.GetLength(1); col++)
                {
                    char currChar = beeTerritory[row, col];

                    if (currChar == 'B')
                    {
                        return new Tuple<int, int>(row, col);
                    }
                }
            }

            return null;
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
