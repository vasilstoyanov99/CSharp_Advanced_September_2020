using System;
using System.IO;

namespace _04.Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader readerOne = new StreamReader("../../../FileOne.txt"))
            {
                using (StreamReader readerTwo = new StreamReader("../../../FileTwo.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("../../../result.txt"))
                    {
                        string readFromOne = readerOne.ReadLine();
                        string readFromTwo = readerTwo.ReadLine();
                        bool shoudlCycleEnd = false;

                        while (true)
                        {
                            if (readerOne != null)
                            {
                                writer.Write(readFromOne);

                                if (!shoudlCycleEnd)
                                {
                                    writer.WriteLine();
                                }
                            }

                            if (readerTwo != null)
                            {
                                writer.Write(readFromTwo);

                                if (!shoudlCycleEnd)
                                {
                                    writer.WriteLine();
                                }
                            }
                            
                            readFromOne = readerOne.ReadLine();
                            readFromTwo = readerTwo.ReadLine();

                            if (shoudlCycleEnd)
                            {
                                break;
                            }

                            if (readerOne.EndOfStream == true && readerTwo.EndOfStream == true)
                            {
                                shoudlCycleEnd = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
