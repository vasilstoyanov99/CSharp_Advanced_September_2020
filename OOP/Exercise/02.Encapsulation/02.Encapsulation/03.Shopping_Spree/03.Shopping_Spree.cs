using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace _03.Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleRaw = Console.ReadLine().Split('=', ';');
            string[] productsRaw = Console.ReadLine().Split('=', ';');
            var allPeople = new Dictionary<string, Person>();
            var allProducts = new Dictionary<string, Product>();
            AddPeople(peopleRaw, allPeople);
            AddProducts(productsRaw, allProducts);
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] data = input.Split();
                string name = data[0];
                string product = data[1];
                allPeople[name].CheckIfPersonCanBuy(allProducts[product]);
                input = Console.ReadLine();
            }

            foreach (var person in allPeople.Values)
            {
                Console.WriteLine($"{person.Name} - {person}");
            }
        }

        static void AddPeople(string[] peopleRaw, Dictionary<string, Person> allPeople)
        {
            for (int i = 0; i < peopleRaw.Length - 1; i++)
            {
                string name = peopleRaw[i].Trim().ToString();
                double money = double.Parse(peopleRaw[++i].Trim());

                try
                {
                    Person person = new Person(name, money);
                    allPeople.Add(name, person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }

        static void AddProducts(string[] productsRaw, Dictionary<string, Product> allProducts)
        {
            for (int i = 0; i < productsRaw.Length - 1; i++)
            {
                string name = productsRaw[i].Trim().ToString();
                double cost = double.Parse(productsRaw[++i].Trim());

                try
                {
                    Product product = new Product(name, cost);
                    allProducts.Add(name, product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
