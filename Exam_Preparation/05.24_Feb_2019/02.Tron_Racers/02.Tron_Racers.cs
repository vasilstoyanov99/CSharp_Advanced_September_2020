using System;

namespace _02.Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixDimensions = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(matrixDimensions, matrixDimensions);
            bool didThePlayerDied = false;
            Tuple<int, int> fisrtPlayerPosition = GetFisrtPlayerPosition(matrix);
            Tuple<int, int> secondPlayerPosition = GetSecondPlayerPosition(matrix);

            while (!didThePlayerDied)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "up":
                        didThePlayerDied = MoveUp(matrix, ref fisrtPlayerPosition, 'f');
                        break;
                    case "down":
                        didThePlayerDied = MoveDown(matrix, ref fisrtPlayerPosition, 'f');
                        break;
                    case "left":
                        didThePlayerDied = MoveLeft(matrix, ref fisrtPlayerPosition, 'f');
                        break;
                    case "right":
                        didThePlayerDied = MoveRight(matrix, ref fisrtPlayerPosition, 'f');
                        break;
                }

                if (didThePlayerDied)
                {
                    break;
                }

                switch (commands[1])
                {
                    case "up":
                        didThePlayerDied = MoveUp(matrix, ref secondPlayerPosition, 's');
                        break;
                    case "down":
                        didThePlayerDied = MoveDown(matrix, ref secondPlayerPosition, 's');
                        break;
                    case "left":
                        didThePlayerDied = MoveLeft(matrix, ref secondPlayerPosition, 's');
                        break;
                    case "right":
                        didThePlayerDied = MoveRight(matrix, ref secondPlayerPosition, 's');
                        break;
                }
            }

            PrintMatrix(matrix);
        }
        
        static bool MoveUp(char[,] matrix, ref Tuple<int, int> playerPosition, char playerMark)
        {
            int nextRowIndex = playerPosition.Item1 - 1;
            int currColIndex = playerPosition.Item2;
            nextRowIndex = CheckAndRepositionPlayerUp(nextRowIndex, matrix.GetLength(0));
            char landingSpot = matrix[nextRowIndex, currColIndex];

            if (landingSpot == '*')
            {
                matrix[nextRowIndex, currColIndex] = playerMark;
            }
            else if (landingSpot != playerMark)
            {
                matrix[nextRowIndex, currColIndex] = 'x';
                return true;
            }

            playerPosition = new Tuple<int, int>(nextRowIndex, currColIndex);
            return false;
        }

        static bool MoveDown(char[,] matrix, ref Tuple<int, int> playerPosition, char playerMark)
        {
            int nextRowIndex = playerPosition.Item1 + 1;
            int currColIndex = playerPosition.Item2;
            nextRowIndex = CheckAndRepositionPlayerDown(nextRowIndex, matrix.GetLength(0));
            char landingSpot = matrix[nextRowIndex, currColIndex];

            if (landingSpot == '*')
            {
                matrix[nextRowIndex, currColIndex] = playerMark;
            }
            else if (landingSpot != playerMark)
            {
                matrix[nextRowIndex, currColIndex] = 'x';
                return true;
            }

            playerPosition = new Tuple<int, int>(nextRowIndex, currColIndex);
            return false;
        }

        static bool MoveLeft(char[,] matrix, ref Tuple<int, int> playerPosition, char playerMark)
        {
            int currRowIndex = playerPosition.Item1;
            int nextColIndex = playerPosition.Item2 - 1;
            nextColIndex = CheckAndRepositionPlayerLeft(nextColIndex, matrix.GetLength(1));
            char landingSpot = matrix[currRowIndex, nextColIndex];

            if (landingSpot == '*')
            {
                matrix[currRowIndex, nextColIndex] = playerMark;
            }
            else if (landingSpot != playerMark)
            {
                matrix[currRowIndex, nextColIndex] = 'x';
                return true;
            }

            playerPosition = new Tuple<int, int>(currRowIndex, nextColIndex);
            return false;
        }

        static bool MoveRight(char[,] matrix, ref Tuple<int, int> playerPosition, char playerMark)
        {
            int currRowIndex = playerPosition.Item1;
            int nextColIndex = playerPosition.Item2 + 1;
            nextColIndex = CheckAndRepositionPlayerRight(nextColIndex, matrix.GetLength(1));
            char landingSpot = matrix[currRowIndex, nextColIndex];

            if (landingSpot == '*')
            {
                matrix[currRowIndex, nextColIndex] = playerMark;
            }
            else if (landingSpot != playerMark)
            {
                matrix[currRowIndex, nextColIndex] = 'x';
                return true;
            }

            playerPosition = new Tuple<int, int>(currRowIndex, nextColIndex);
            return false;
        }

        static int CheckAndRepositionPlayerRight(int nextColIndex, int colLength)
        {
            if (nextColIndex >= colLength)
            {
                nextColIndex = 0;
            }

            return nextColIndex;
        }

        static int CheckAndRepositionPlayerLeft(int nextColIndex, int colLength)
        {
            if (nextColIndex < 0)
            {
                nextColIndex = colLength - 1;
            }

            return nextColIndex;
        }

        static int CheckAndRepositionPlayerDown(int nextRowIndex, int rowLength)
        {
            if (nextRowIndex >= rowLength)
            {
                nextRowIndex = 0;
            }

            return nextRowIndex;
        }

        static int CheckAndRepositionPlayerUp(int nextRowIndex, int rowLength)
        {
            if (nextRowIndex < 0)
            {
                nextRowIndex = rowLength - 1;
            }

            return nextRowIndex;
        }

        static Tuple<int, int> GetFisrtPlayerPosition(char[,] matrix)
        {
            var position = new Tuple<int, int>(0, 0);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currChar = matrix[row, col];

                    if (currChar == 'f')
                    {
                        return position = new Tuple<int, int>(row, col);
                    }
                }
            }

            return null;
        }

        static Tuple<int, int> GetSecondPlayerPosition(char[,] matrix)
        {
            var position = new Tuple<int, int>(0, 0);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currChar = matrix[row, col];

                    if (currChar == 's')
                    {
                        return position = new Tuple<int, int>(row, col);
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
