using System;
using System.Collections.Generic;

namespace _03.Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separetors = new char[] { '=', ';', ' ' };
            string[] people = Console.ReadLine().Split(separetors, StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine().Split(separetors, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Person> allPeople = new Dictionary<string, Person>();
            Dictionary<string, Product> allProducts = new Dictionary<string, Product>();

            foreach (var person in people)
            {
                
            }
        }
    }
}
