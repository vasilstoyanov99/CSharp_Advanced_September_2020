using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace _01.Custom_List
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> myCustomList = new CustomList<string>();
            myCustomList.Add("Try");
            myCustomList.Add("Me");
            myCustomList.Add("Pls!!");
            myCustomList.InsertAt(0, "Hehe");
            myCustomList.InsertAt(2, "Mana");
            Console.WriteLine(myCustomList);
            Console.WriteLine(myCustomList.Contains("Bug"));
            Console.WriteLine(myCustomList.FindIndex("Me"));
            Console.WriteLine(myCustomList.FindIndex("ME"));
            myCustomList.Reverse();
            Console.WriteLine(myCustomList);
            myCustomList.RemoveAt(0);
            Console.WriteLine($"Removed element at index 0: {myCustomList.RemoveAt(0)}");
            myCustomList.RemoveAt(-5);


        }
    }
}
