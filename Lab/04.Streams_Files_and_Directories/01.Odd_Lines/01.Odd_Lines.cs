using System;
using System.IO;

namespace _01.Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../ToSplit.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../OnlyOddLines.txt"))
                {
                    int linesCounter = 0;
                    string read = reader.ReadLine();

                    while (read != null)
                    {
                        linesCounter++;

                        if (linesCounter % 2 == 1)
                        {
                            writer.Write(read);
                            writer.Write(Environment.NewLine);
                        }

                        read = reader.ReadLine();
                    }
                }
            } 
        }
    }
}
