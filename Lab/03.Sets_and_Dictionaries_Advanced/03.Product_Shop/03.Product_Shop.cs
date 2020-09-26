using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();
            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = data[0];
                string product = data[1];
                double price = double.Parse(data[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                    shops[shop].Add(product, price);
                }
                else
                {
                    shops[shop].Add(product, price);
                }

                input = Console.ReadLine();
            }

            shops = shops.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
