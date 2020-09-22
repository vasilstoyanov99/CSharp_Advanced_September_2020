using System;
using System.Linq;

namespace _5.Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            int rows = data[0];
            int cols = data[1];
            char[,] matrix = new char[rows, cols];
            int zigZagCounter = 0;
            int lastSnakeIndex = 0;
            bool isSnakeLenghtEqualToCollumLenght = snake.Length == cols;

            for (int row = 0; row < rows; row++)
            {
                zigZagCounter++;

                for (int col = 0; col < cols; col++)
                {
                    if (zigZagCounter % 2 != 0)
                    {
                        if (isSnakeLenghtEqualToCollumLenght)
                        {
                            matrix[row, col] = snake[col];
                        }
                        else
                        {
                            matrix[row, col] = snake[lastSnakeIndex];
                            lastSnakeIndex++;

                            if (lastSnakeIndex == snake.Length)
                            {
                                lastSnakeIndex = 0;
                            }
                        }
                    }
                    else
                    {
                        for (int reverse = cols - 1; reverse >= 0; reverse--)
                        {
                            if (isSnakeLenghtEqualToCollumLenght)
                            {
                                int index = 0;

                                for (int snakeIndex = snake.Length - 1; snakeIndex >= 0; snakeIndex--)
                                {
                                    matrix[row, snakeIndex] = snake[index];
                                    index++;
                                }

                                break;
                            }
                            else
                            {
                                matrix[row, reverse] = snake[lastSnakeIndex];
                                lastSnakeIndex++;

                                if (lastSnakeIndex == snake.Length)
                                {
                                    lastSnakeIndex = 0;
                                }
                            }
                        }

                        break;
                    }
                }

            }

            PrintMatrix(matrix);
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
