using System;
using System.Collections.Generic;

namespace _01.Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            HashSet<string> uniqueUsernames = new HashSet<string>();
            
            for (int i = 0; i < numberOfInputs; i++)
            {
                string username = Console.ReadLine();
                uniqueUsernames.Add(username);
            }

            foreach (var username in uniqueUsernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
