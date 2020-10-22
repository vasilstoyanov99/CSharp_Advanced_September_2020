using System;
using System.Linq;

namespace _02.Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPresents = int.Parse(Console.ReadLine());
            int matrixDimensions = int.Parse(Console.ReadLine());
            char[,] neighbourhood = ReadMatrix(matrixDimensions, matrixDimensions);
            Tuple<int, int> santaPosition = FindSanta(neighbourhood);
            neighbourhood[santaPosition.Item1, santaPosition.Item2] = '-';
            int niceKidsCount = GetNiceKidsCount(neighbourhood);
            int copyOfNiceKidsCount = niceKidsCount;
            string command = Console.ReadLine();
            bool doesSantaRanOutOfPresents = false;

            while (command != "Christmas morning")
            {
                switch (command)
                {
                    case "up":
                        MoveUp(neighbourhood, ref santaPosition, ref niceKidsCount, ref countOfPresents);
                        doesSantaRanOutOfPresents = CheckIfSantaRanOutOfPresents(countOfPresents);
                        break;
                    case "down":
                        MoveDown(neighbourhood, ref santaPosition, ref niceKidsCount, ref countOfPresents);
                        doesSantaRanOutOfPresents = CheckIfSantaRanOutOfPresents(countOfPresents);
                        break;
                    case "left":
                        MoveLeft(neighbourhood, ref santaPosition, ref niceKidsCount, ref countOfPresents);
                        doesSantaRanOutOfPresents = CheckIfSantaRanOutOfPresents(countOfPresents);
                        break;
                    case "right":
                        MoveRight(neighbourhood, ref santaPosition, ref niceKidsCount, ref countOfPresents);
                        doesSantaRanOutOfPresents = CheckIfSantaRanOutOfPresents(countOfPresents);
                        break;
                }

                if (doesSantaRanOutOfPresents)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (doesSantaRanOutOfPresents)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            neighbourhood[santaPosition.Item1, santaPosition.Item2] = 'S';
            PrintMatrix(neighbourhood);

            if (niceKidsCount <= 0)
            {
                Console.WriteLine($"Good job, Santa! {copyOfNiceKidsCount} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKidsCount} nice kid/s.");
            }
        }

        static void MoveRight(char[,] neighbourhood, ref Tuple<int, int> santaPosition, ref int niceKidsCount, ref int countOfPresents)
        {
            int currRowIndex = santaPosition.Item1;
            int nextColIndex = santaPosition.Item2 + 1;
            char landingSpot = neighbourhood[currRowIndex, nextColIndex];

            switch (landingSpot)
            {
                case 'V':
                    countOfPresents--;
                    niceKidsCount--;
                    neighbourhood[currRowIndex, nextColIndex] = '-';
                    break;
                case 'X':
                    neighbourhood[currRowIndex, nextColIndex] = '-';
                    break;
                case 'C':
                    MakeSantaGenerous(neighbourhood, currRowIndex, nextColIndex, ref niceKidsCount, ref countOfPresents);
                    break;
            }

            santaPosition = new Tuple<int, int>(currRowIndex, nextColIndex);
        }

        static void MoveLeft(char[,] neighbourhood, ref Tuple<int, int> santaPosition, ref int niceKidsCount, ref int countOfPresents)
        {
            int currRowIndex = santaPosition.Item1;
            int nextColIndex = santaPosition.Item2 - 1;
            char landingSpot = neighbourhood[currRowIndex, nextColIndex];

            switch (landingSpot)
            {
                case 'V':
                    countOfPresents--;
                    niceKidsCount--;
                    neighbourhood[currRowIndex, nextColIndex] = '-';
                    break;
                case 'X':
                    neighbourhood[currRowIndex, nextColIndex] = '-';
                    break;
                case 'C':
                    MakeSantaGenerous(neighbourhood, currRowIndex, nextColIndex, ref niceKidsCount, ref countOfPresents);
                    break;
            }

            santaPosition = new Tuple<int, int>(currRowIndex, nextColIndex);
        }

        static void MoveUp(char[,] neighbourhood, ref Tuple<int, int> santaPosition, ref int niceKidsCount, ref int countOfPresents)
        {
            int nextRowIndex = santaPosition.Item1 - 1;
            int currColIndex = santaPosition.Item2;
            char landingSpot = neighbourhood[nextRowIndex, currColIndex];

            switch (landingSpot)
            {
                case 'V':
                    countOfPresents--;
                    niceKidsCount--;
                    neighbourhood[nextRowIndex, currColIndex] = '-';
                    break;
                case 'X':
                    neighbourhood[nextRowIndex, currColIndex] = '-';
                    break;
                case 'C':
                    MakeSantaGenerous(neighbourhood, nextRowIndex, currColIndex, ref niceKidsCount, ref countOfPresents);
                    break;
            }

            santaPosition = new Tuple<int, int>(nextRowIndex, currColIndex);
        }

        static void MoveDown(char[,] neighbourhood, ref Tuple<int, int> santaPosition, ref int niceKidsCount, ref int countOfPresents)
        {
            int nextRowIndex = santaPosition.Item1 + 1;
            int currColIndex = santaPosition.Item2;
            char landingSpot = neighbourhood[nextRowIndex, currColIndex];

            switch (landingSpot)
            {
                case 'V':
                    countOfPresents--;
                    niceKidsCount--;
                    neighbourhood[nextRowIndex, currColIndex] = '-';
                    break;
                case 'X':
                    neighbourhood[nextRowIndex, currColIndex] = '-';
                    break;
                case 'C':
                    MakeSantaGenerous(neighbourhood, nextRowIndex, currColIndex, ref niceKidsCount, ref countOfPresents);
                    break;
            }

            santaPosition = new Tuple<int, int>(nextRowIndex, currColIndex);
        }

        static void MakeSantaGenerous(char[,] neighbourhood, int rowIndex, int colIndex,  ref int niceKidsCount, ref int countOfPresents)
        {
            char up = neighbourhood[rowIndex - 1, colIndex];
            char down = neighbourhood[rowIndex + 1, colIndex];
            char left = neighbourhood[rowIndex, colIndex - 1];
            char right = neighbourhood[rowIndex, colIndex + 1];

            if (up == 'X')
            {
                countOfPresents--;
                neighbourhood[rowIndex - 1, colIndex] = '-';

            }
            else if (up == 'V')
            {
                niceKidsCount--;
                countOfPresents--;
                neighbourhood[rowIndex - 1, colIndex] = '-';
            }

            if (down == 'X')
            {
                countOfPresents--;
                neighbourhood[rowIndex + 1, colIndex] = '-';

            }
            else if (down == 'V')
            {
                niceKidsCount--;
                countOfPresents--;
                neighbourhood[rowIndex + 1, colIndex] = '-';
            }

            if (left == 'X')
            {
                countOfPresents--;
                neighbourhood[rowIndex, colIndex - 1] = '-';

            }
            else if (left == 'V')
            {
                niceKidsCount--;
                countOfPresents--;
                neighbourhood[rowIndex, colIndex - 1] = '-';
            }

            if (right == 'X')
            {
                countOfPresents--;
                neighbourhood[rowIndex, colIndex + 1] = '-';

            }
            else if (right == 'V')
            {
                niceKidsCount--;
                countOfPresents--;
                neighbourhood[rowIndex, colIndex + 1] = '-';
            }
        }

        static bool CheckIfSantaRanOutOfPresents(int countOfPresents)
        {
            return countOfPresents <= 0;
        }

        static int GetNiceKidsCount(char[,] neighbourhood)
        {
            int count = 0;

            for (int row = 0; row < neighbourhood.GetLength(0); row++)
            {
                for (int col = 0; col < neighbourhood.GetLength(1); col++)
                {
                    char currChar = neighbourhood[row, col];

                    if (currChar == 'V')
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        static Tuple<int, int> FindSanta(char[,] neighbourhood )
        {
            Tuple<int, int> position = new Tuple<int, int>(0, 0);

            for (int row = 0; row < neighbourhood.GetLength(0); row++)
            {
                for (int col = 0; col < neighbourhood.GetLength(1); col++)
                {
                    char currChar = neighbourhood[row, col];

                    if (currChar == 'S')
                    {
                        position = new Tuple<int, int>(row, col);
                        return position;
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
            string[] raw =  Console.ReadLine().Split(separetors, StringSplitOptions.RemoveEmptyEntries).ToArray();
            char[] toReturn = raw.Select(x => x[0]).ToArray();
            return toReturn;
        }

        static void PrintMatrix(char[,] matrix)
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
    }
}
