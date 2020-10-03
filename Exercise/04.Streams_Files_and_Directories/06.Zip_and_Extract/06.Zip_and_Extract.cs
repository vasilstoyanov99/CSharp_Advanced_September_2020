using System;
using System.IO.Compression;

namespace _06.Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string archiveFrom = @"C:\Users\Vasko\Documents\FromFile";
            string to = @"C:\Users\Vasko\Documents\ToFile\MyZipFile.zip";
            ZipFile.CreateFromDirectory(archiveFrom, to);
            string extractFrom = @"C:\Users\Vasko\Documents\ToFile\MyZipFile.zip";
            string toArriveHere = @"C:\Users\Vasko\Documents\ToExtractHere\MyUnZipedFile";
            ZipFile.ExtractToDirectory(extractFrom, toArriveHere);

        }
    }
}
