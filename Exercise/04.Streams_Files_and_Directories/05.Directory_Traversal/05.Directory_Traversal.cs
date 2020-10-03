using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path: ");
            string path = Console.ReadLine();
            var files = new Dictionary<string, Dictionary<string, long>>();
            string[] directories = Directory.GetFiles(path);

            foreach (var fileToAdd in directories)
            {
                AddFileInfo(files, fileToAdd);
            }

            string strPath = Environment.GetFolderPath(
                         System.Environment.SpecialFolder.DesktopDirectory);

            using (StreamWriter writer = new StreamWriter(strPath + "/report.txt"))
            {
                files = files.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

                foreach (var extention in files)
                {
                    writer.Write(extention.Key);
                    writer.WriteLine();

                    foreach (var fileData in extention.Value.OrderBy(x => x.Value))
                    {
                        writer.Write($"--{fileData.Key} - {fileData.Value / 1024.00:f2}kb");
                        writer.WriteLine();
                    }
                }
            }
            
        }

        static void AddFileInfo(Dictionary<string, Dictionary<string, long>> files, string fileToAdd)
        {
            FileInfo fileInfo = new FileInfo(fileToAdd);
            string fileExtention = fileInfo.Extension;

            if (fileInfo.Exists)
            {
                if (!files.ContainsKey(fileExtention))
                {
                    files.Add(fileExtention, new Dictionary<string, long>());
                }

                files[fileExtention].Add(fileInfo.FullName, fileInfo.Length);
            }
        }
    }
}
