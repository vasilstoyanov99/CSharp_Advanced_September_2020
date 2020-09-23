using System;

namespace _7.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());
            char[,] chessBoard = ReadMatrix(boardSize, boardSize);
            int killerRow = 0;
            int killerCol = 0;
            int replacedKillerKnights = 0;

            while (true)
            {
                int maxAttacks = 0;

                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {
                        char currSymbol = chessBoard[row, col];

                        if (currSymbol == 'K')
                        {
                            int currAttacks = GetAttacks(chessBoard, row, col);

                            if (currAttacks > maxAttacks)
                            {
                                maxAttacks = currAttacks;
                                killerRow = row;
                                killerCol = col;
                            }
                        }
                    }
                }

                if (maxAttacks <= 0)
                {
                    Console.WriteLine(replacedKillerKnights);
                    break;
                }
                else
                {
                    chessBoard[killerRow, killerCol] = '0';
                    replacedKillerKnights++;
                }
            }
        }

        static int GetAttacks(char[,] chessBoard, int row, int col)
        {
            int totalAttacks = 0;

            if (AreIndexesInside(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
            {
                totalAttacks++;
            }

            if (AreIndexesInside(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
            {
                totalAttacks++;
            }

            if (AreIndexesInside(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
            {
                totalAttacks++;
            }

            if (AreIndexesInside(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
            {
                totalAttacks++;
            }

            if (AreIndexesInside(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
            {
                totalAttacks++;
            }

            if (AreIndexesInside(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
            {
                totalAttacks++;
            }

            if (AreIndexesInside(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
            {
                totalAttacks++;
            }

            if (AreIndexesInside(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
            {
                totalAttacks++;
            }

            return totalAttacks;
        }

        static bool AreIndexesInside(char[,] chessBoard, int row, int col)
        {
            return (row >= 0 && row < chessBoard.GetLength(0) && col >= 0 && col < chessBoard.GetLength(1));
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
    }
}
