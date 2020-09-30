using System;
using System.IO;

namespace _05.Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../sliceMe.txt"))
            {
                int partsCounter = 0;
                string read = reader.ReadLine();

                while (read != null)
                {
                    if (read != String.Empty)
                    {
                        partsCounter++;

                        using (StreamWriter writer = new StreamWriter($"../../../Part-{partsCounter}.txt"))
                        {
                            writer.Write(read);
                        }
                    }

                    read = reader.ReadLine();
                }
            }
        }
    }
}
