using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixDimensions = int.Parse(Console.ReadLine());
            char[,] snakeTerritory = ReadMatrix(matrixDimensions, matrixDimensions);
            char[,] snakeTerritoryCopy = (char[,])snakeTerritory.Clone();
            Tuple<int, int> burrowFirstPosition = GetFirstBurrowPosition(snakeTerritoryCopy);
            Tuple<int, int> burrowSecondPosition = new Tuple<int, int>(0, 0);
            int eatenFood = 0;
            bool isSnakeOutOfTerritory = false;

            if (burrowFirstPosition != null)
            {
                burrowSecondPosition = GetSecondBurrowPosition(snakeTerritoryCopy);
            }

            Tuple<int, int> snakePosition = GetSnakePosition(snakeTerritory);

            while (eatenFood < 10)
            {
                if (isSnakeOutOfTerritory)
                {
                    break;
                }

                string moveCommand = Console.ReadLine().Trim();

                switch (moveCommand)
                {
                    case "up":
                        isSnakeOutOfTerritory = MoveUp(snakeTerritory, ref snakePosition, 
                            burrowFirstPosition, burrowSecondPosition, ref eatenFood);
                        break;
                    case "down":
                        isSnakeOutOfTerritory = MoveDown(snakeTerritory, ref snakePosition,
                            burrowFirstPosition, burrowSecondPosition, ref eatenFood);
                        break;
                    case "left":
                        isSnakeOutOfTerritory = MoveLeft(snakeTerritory, ref snakePosition,
                            burrowFirstPosition, burrowSecondPosition, ref eatenFood);
                        break;
                    case "right":
                        isSnakeOutOfTerritory = MoveRight(snakeTerritory, ref snakePosition,
                            burrowFirstPosition, burrowSecondPosition, ref eatenFood);
                        break;
                }
            }

            if (isSnakeOutOfTerritory)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
                snakeTerritory[snakePosition.Item1, snakePosition.Item2] = 'S';
            }

            Console.WriteLine($"Food eaten: {eatenFood}");
            PrintMatrix(snakeTerritory);
        }

        static bool CheckIfSnakeIsInTheTerritory(int row, int col, char[,] snakeTerritory)
        {
            return (row >= 0 && row < snakeTerritory.GetLength(0) && (col >= 0 && col < snakeTerritory.GetLength(1)));
        }

        static bool MoveRight(char[,] snakeTerritory, ref Tuple<int, int> snakePosition, Tuple<int, int> burrowFirstPosition,
            Tuple<int, int> burrowSecondPosition, ref int eatenFood)
        {
            int snakeRowIndex = snakePosition.Item1;
            int snakeNextColIndex = snakePosition.Item2 + 1;

            if (CheckIfSnakeIsInTheTerritory(snakeRowIndex, snakeNextColIndex, snakeTerritory))
            {
                char landingSpot = snakeTerritory[snakeRowIndex, snakeNextColIndex];
                snakePosition = new Tuple<int, int>(snakeRowIndex, snakeNextColIndex);

                if (landingSpot == '*')
                {
                    eatenFood++;
                    snakeTerritory[snakeRowIndex, snakeNextColIndex] = '.';
                    return false;
                }
                else if (landingSpot == 'B')
                {
                    snakeTerritory[burrowFirstPosition.Item1, burrowFirstPosition.Item2] = '.';
                    snakeTerritory[burrowSecondPosition.Item1, burrowSecondPosition.Item2] = '.';
                    snakePosition = new Tuple<int, int>(burrowSecondPosition.Item1, burrowSecondPosition.Item2);
                    return false;
                }
                else
                {
                    snakeTerritory[snakeRowIndex, snakeNextColIndex] = '.';
                    return false;
                }
            }

            return true;
        }

        static bool MoveLeft(char[,] snakeTerritory, ref Tuple<int, int> snakePosition, Tuple<int, int> burrowFirstPosition,
            Tuple<int, int> burrowSecondPosition, ref int eatenFood)
        {
            int snakeRowIndex = snakePosition.Item1;
            int snakeNextColIndex = snakePosition.Item2 - 1;

            if (CheckIfSnakeIsInTheTerritory(snakeRowIndex, snakeNextColIndex, snakeTerritory))
            {
                char landingSpot = snakeTerritory[snakeRowIndex, snakeNextColIndex];
                snakePosition = new Tuple<int, int>(snakeRowIndex, snakeNextColIndex);

                if (landingSpot == '*')
                {
                    eatenFood++;
                    snakeTerritory[snakeRowIndex, snakeNextColIndex] = '.';
                    return false;
                }
                else if (landingSpot == 'B')
                {
                    snakeTerritory[burrowFirstPosition.Item1, burrowFirstPosition.Item2] = '.';
                    snakeTerritory[burrowSecondPosition.Item1, burrowSecondPosition.Item2] = '.';
                    snakePosition = new Tuple<int, int>(burrowSecondPosition.Item1, burrowSecondPosition.Item2);
                    return false;
                }
                else
                {
                    snakeTerritory[snakeRowIndex, snakeNextColIndex] = '.';
                    return false;
                }
            }

            return true;
        }

        static bool MoveUp(char[,] snakeTerritory, ref Tuple<int, int> snakePosition, Tuple<int, int> burrowFirstPosition,
            Tuple<int, int> burrowSecondPosition, ref int eatenFood)
        {
            int snakeNextRowIndex = snakePosition.Item1 - 1;
            int snakeColIndex = snakePosition.Item2;

            if (CheckIfSnakeIsInTheTerritory(snakeNextRowIndex, snakeColIndex, snakeTerritory))
            {
                char landingSpot = snakeTerritory[snakeNextRowIndex, snakeColIndex];
                snakePosition = new Tuple<int, int>(snakeNextRowIndex, snakeColIndex);

                if (landingSpot == '*')
                {
                    eatenFood++;
                    snakeTerritory[snakeNextRowIndex, snakeColIndex] = '.';
                    return false;
                }
                else if (landingSpot == 'B')
                {
                    snakeTerritory[burrowFirstPosition.Item1, burrowFirstPosition.Item2] = '.';
                    snakeTerritory[burrowSecondPosition.Item1, burrowSecondPosition.Item2] = '.';
                    snakePosition = new Tuple<int, int>(burrowSecondPosition.Item1, burrowSecondPosition.Item2);
                    return false;
                }
                else
                {
                    snakeTerritory[snakeNextRowIndex, snakeColIndex] = '.';
                    return false;
                }
            }

            return true;
        }

        static bool MoveDown(char[,] snakeTerritory, ref Tuple<int, int> snakePosition, Tuple<int, int> burrowFirstPosition,
           Tuple<int, int> burrowSecondPosition, ref int eatenFood)
        {
            int snakeNextRowIndex = snakePosition.Item1 + 1;
            int snakeColIndex = snakePosition.Item2;

            if (CheckIfSnakeIsInTheTerritory(snakeNextRowIndex, snakeColIndex, snakeTerritory))
            {
                char landingSpot = snakeTerritory[snakeNextRowIndex, snakeColIndex];
                snakePosition = new Tuple<int, int>(snakeNextRowIndex, snakeColIndex);

                if (landingSpot == '*')
                {
                    eatenFood++;
                    snakeTerritory[snakeNextRowIndex, snakeColIndex] = '.';
                    return false;
                }
                else if (landingSpot == 'B')
                {
                    snakeTerritory[burrowFirstPosition.Item1, burrowFirstPosition.Item2] = '.';
                    snakeTerritory[burrowSecondPosition.Item1, burrowSecondPosition.Item2] = '.';
                    snakePosition = new Tuple<int, int>(burrowSecondPosition.Item1, burrowSecondPosition.Item2);
                    return false;
                }
                else
                {
                    snakeTerritory[snakeNextRowIndex, snakeColIndex] = '.';
                    return false;
                     
                }
            }

            return true;
        }

        static Tuple<int, int> GetFirstBurrowPosition(char[,] snakeTerritoryCopy)
        {
            Tuple<int, int> positions = new Tuple<int, int>(0, 0);

            for (int row = 0; row < snakeTerritoryCopy.GetLength(0); row++)
            {
                for (int col = 0; col < snakeTerritoryCopy.GetLength(1); col++)
                {
                    char currChar = snakeTerritoryCopy[row, col];

                    if (currChar == 'B')
                    {
                        snakeTerritoryCopy[row, col] = '$';
                        positions = new Tuple<int, int>(row, col);
                        return positions;
                    }
                }
            }

            return null;
        }
        
        static Tuple<int, int> GetSecondBurrowPosition(char[,] snakeTerritoryCopy)
        {
            Tuple<int, int> positions = new Tuple<int, int>(0, 0);

            for (int row = 0; row < snakeTerritoryCopy.GetLength(0); row++)
            {
                for (int col = 0; col < snakeTerritoryCopy.GetLength(1); col++)
                {
                    char currChar = snakeTerritoryCopy[row, col];

                    if (currChar == 'B')
                    {
                        positions = new Tuple<int, int>(row, col);
                        return positions;
                    }
                }
            }

            return null;
        }

        static Tuple<int, int> GetSnakePosition(char[,] snakeTerritory)
        {
            Tuple<int, int> positions = new Tuple<int, int>(0, 0);

            for (int row = 0; row < snakeTerritory.GetLength(0); row++)
            {
                for (int col = 0; col < snakeTerritory.GetLength(1); col++)
                {
                    char currChar = snakeTerritory[row, col];

                    if (currChar == 'S')
                    {
                        positions = new Tuple<int, int>(row, col);
                        snakeTerritory[positions.Item1, positions.Item2] = '.';
                        return positions;
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
