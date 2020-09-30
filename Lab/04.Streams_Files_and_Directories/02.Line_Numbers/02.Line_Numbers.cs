using System;
using System.IO;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../Text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../Result.txt"))
                {
                    int lineIndex = 1;
                    string read = reader.ReadLine();

                    while (read != null)
                    {
                        writer.Write($"{lineIndex}. {read}");
                        writer.Write(Environment.NewLine);
                        read = reader.ReadLine();
                        lineIndex++;
                    }
                }
            }
        }
    }
}
