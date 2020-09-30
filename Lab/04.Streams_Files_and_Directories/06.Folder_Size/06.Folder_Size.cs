using System;
using System.IO;

namespace _06.Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Console.ReadLine();
            string[] files = Directory.GetFiles(directoryPath);
            double sum = 0;

            for (int currFile = 0; currFile < files.Length; currFile++)
            {
                FileInfo info = new FileInfo(files[currFile]);
                Console.WriteLine(info.FullName);
                sum += info.Length;
            }

            decimal MB = (decimal)(sum / 1000000.00);
            Console.WriteLine($"Bytes: {sum}");
            Console.WriteLine($"MB: {MB:f2}");
        }
    }
}
