using System;
using System.Data;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixDimensions = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());
            char[,] playerTerritory = ReadMatrix(matrixDimensions, matrixDimensions);
            Tuple<int, int> playerPosition = GetPlayerPosition(playerTerritory);
            playerTerritory[playerPosition.Item1, playerPosition.Item2] = '-';
            bool isPlayerOnTheFinishLine = false;

            for (int i = 0; i < countOfCommands; i++)
            {
                if (isPlayerOnTheFinishLine)
                {
                    break;
                }

                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        isPlayerOnTheFinishLine = MoveUp(playerTerritory, ref playerPosition);
                        break;
                    case "down":
                        isPlayerOnTheFinishLine = MoveDown(playerTerritory, ref playerPosition);
                        break;
                    case "left":
                        isPlayerOnTheFinishLine = MoveLeft(playerTerritory, ref playerPosition);
                        break;
                    case "right":
                        isPlayerOnTheFinishLine = MoveRight(playerTerritory, ref playerPosition);
                        break;
                }
            }

            playerTerritory[playerPosition.Item1, playerPosition.Item2] = 'f';

            if (isPlayerOnTheFinishLine)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(playerTerritory);
        }

        static bool MoveUp(char[,] playerTerritory, ref Tuple<int, int> playerPosition)
        {
            int nextRowIndex = playerPosition.Item1 - 1;
            int currColIndex = playerPosition.Item2;
            bool isPlayerRepositioned = false;
            bool isPlayerOnTheFinishLine = false;
            nextRowIndex = CheckAndRepositionPlayerUp(nextRowIndex, playerTerritory.GetLength(0), ref isPlayerRepositioned);

            char landingSpot = playerTerritory[nextRowIndex, currColIndex];

            switch (landingSpot)
            {
                case 'B':
                    nextRowIndex--;

                    if (!isPlayerRepositioned)
                    {
                        nextRowIndex = CheckAndRepositionPlayerUp(nextRowIndex, playerTerritory.GetLength(0), ref isPlayerRepositioned);
                    }
                    break;
                case 'T':
                    nextRowIndex++;
                    break;
                case 'F':
                    isPlayerOnTheFinishLine = true;
                    break;
            }

            playerPosition = new Tuple<int, int>(nextRowIndex, currColIndex);

            if (isPlayerOnTheFinishLine)
            {
                return true;
            }

            return false;
        }

        static bool MoveDown(char[,] playerTerritory, ref Tuple<int, int> playerPosition)
        {
            int nextRowIndex = playerPosition.Item1 + 1;
            int currColIndex = playerPosition.Item2;
            bool isPlayerRepositioned = false;
            bool isPlayerOnTheFinishLine = false;
            nextRowIndex = CheckAndRepositionPlayerDown(nextRowIndex, playerTerritory.GetLength(0), ref isPlayerRepositioned);

            char landingSpot = playerTerritory[nextRowIndex, currColIndex];

            switch (landingSpot)
            {
                case 'B':
                    nextRowIndex++;

                    if (!isPlayerRepositioned)
                    {
                        nextRowIndex = CheckAndRepositionPlayerDown(nextRowIndex, playerTerritory.GetLength(0), ref isPlayerRepositioned);
                    }
                    break;
                case 'T':
                    nextRowIndex--;
                    break;
                case 'F':
                    isPlayerOnTheFinishLine = true;
                    break;
            }

            playerPosition = new Tuple<int, int>(nextRowIndex, currColIndex);

            if (isPlayerOnTheFinishLine)
            {
                return true;
            }

            return false;
        }

        static bool MoveLeft(char[,] playerTerritory, ref Tuple<int, int> playerPosition)
        {
            int currRowIndex = playerPosition.Item1;
            int nextColIndex = playerPosition.Item2 - 1;
            bool isPlayerRepositioned = false;
            bool isPlayerOnTheFinishLine = false;
            nextColIndex = CheckAndRepositionPlayerLeft(nextColIndex, playerTerritory.GetLength(1), ref isPlayerRepositioned);

            char landingSpot = playerTerritory[currRowIndex, nextColIndex];

            switch (landingSpot)
            {
                case 'B':
                    nextColIndex--;

                    if (!isPlayerRepositioned)
                    {
                        nextColIndex = CheckAndRepositionPlayerLeft(nextColIndex, playerTerritory.GetLength(1), ref isPlayerRepositioned);
                    }
                    break;
                case 'T':
                    nextColIndex++;
                    break;
                case 'F':
                    isPlayerOnTheFinishLine = true;
                    break;
            }

            playerPosition = new Tuple<int, int>(currRowIndex, nextColIndex);

            if (isPlayerOnTheFinishLine)
            {
                return true;
            }

            return false;
        }

        static bool MoveRight(char[,] playerTerritory, ref Tuple<int, int> playerPosition)
        {
            int currRowIndex = playerPosition.Item1;
            int nextColIndex = playerPosition.Item2 + 1;
            bool isPlayerRepositioned = false;
            bool isPlayerOnTheFinishLine = false;
            nextColIndex = CheckAndRepositionPlayerRight(nextColIndex, playerTerritory.GetLength(1), ref isPlayerRepositioned);

            char landingSpot = playerTerritory[currRowIndex, nextColIndex];

            switch (landingSpot)
            {
                case 'B':
                    nextColIndex++;

                    if (!isPlayerRepositioned)
                    {
                        nextColIndex = CheckAndRepositionPlayerRight(nextColIndex, playerTerritory.GetLength(1), ref isPlayerRepositioned);
                    }
                    break;
                case 'T':
                    nextColIndex--;
                    break;
                case 'F':
                    isPlayerOnTheFinishLine = true;
                    break;
            }

            playerPosition = new Tuple<int, int>(currRowIndex, nextColIndex);

            if (isPlayerOnTheFinishLine)
            {
                return true;
            }

            return false;
        }

        static int CheckAndRepositionPlayerRight(int nextColIndex, int colLength, ref bool isPlayerRepositioned)
        {
            if (nextColIndex >= colLength)
            {
                nextColIndex = 0;
                isPlayerRepositioned = true;
            }

            return nextColIndex;
        }

        static int CheckAndRepositionPlayerLeft(int nextColIndex, int colLength, ref bool isPlayerRepositioned)
        {
            if (nextColIndex < 0)
            {
                nextColIndex = colLength - 1;
                isPlayerRepositioned = true;
            }

            return nextColIndex;
        }

        static int CheckAndRepositionPlayerDown(int nextRowIndex, int rowLength, ref bool isPlayerRepositioned)
        {
            if (nextRowIndex >= rowLength)
            {
                nextRowIndex = 0;
                isPlayerRepositioned = true;
            }

            return nextRowIndex;
        }

        static int CheckAndRepositionPlayerUp(int nextRowIndex, int rowLength, ref bool isPlayerRepositioned)
        {
            if (nextRowIndex < 0)
            {
                nextRowIndex = rowLength - 1;
                isPlayerRepositioned = true;
            }

            return nextRowIndex;
        }

        static Tuple<int, int> GetPlayerPosition(char[,] playerTerritory)
        {
            var position = new Tuple<int, int>(0, 0);

            for (int row = 0; row < playerTerritory.GetLength(0); row++)
            {
                for (int col = 0; col < playerTerritory.GetLength(1); col++)
                {
                    char currChar = playerTerritory[row, col];

                    if (currChar == 'f')
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
