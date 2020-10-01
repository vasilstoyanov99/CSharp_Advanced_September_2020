using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _1.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string read = reader.ReadLine();
                int lineCounter = 0;
                StringBuilder result = new StringBuilder();

                while (read != null)
                {
                    if (lineCounter % 2 == 0)
                    {
                        string modified = ReverseAndReplace(read);
                        result.Append(modified);
                        result.AppendLine();
                    }

                    lineCounter++;
                    read = reader.ReadLine();
                }

                Console.WriteLine(result.ToString());
            }
        }

        static string ReverseAndReplace(string text)
        {
            Regex regex = new Regex(@"[-?!\.,:;']");
            string replaced = regex.Replace(text, "@");
            string[] reversed = replaced.Split().ToArray();
            reversed = reversed.Reverse().ToArray();
            return String.Join(" ", reversed);
        }
    }
}
