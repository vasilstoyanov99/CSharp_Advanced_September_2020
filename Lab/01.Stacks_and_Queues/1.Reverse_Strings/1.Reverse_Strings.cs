using System;
using System.Collections.Generic;

namespace _1.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var revrsed = new Stack<char>(input);
            Console.WriteLine(String.Join(String.Empty, revrsed));

        }
    }
}
