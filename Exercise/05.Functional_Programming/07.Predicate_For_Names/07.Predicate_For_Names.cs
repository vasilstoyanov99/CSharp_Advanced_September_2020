using System;

namespace _07.Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenghtCriteria = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            
            foreach (var name in names)
            {
                bool doesNameLenghMeetsCriteria = name.Length <= lenghtCriteria;

                if (doesNameLenghMeetsCriteria)
                {
                    Console.WriteLine(name);
                }
            }

            
        }
    }
}
