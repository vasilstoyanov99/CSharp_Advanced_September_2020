using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("T");
            list.Add("E");
            list.Add("S");
            list.Add("T");
            Console.WriteLine(list.RandomString());
        }
    }
}
