using System;
using System.Collections.Generic;

namespace _04.Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            var data = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] dataToFill = Console.ReadLine().Split();
                string continent = dataToFill[0];
                string country = dataToFill[1];
                string city = dataToFill[2];

                if (!data.ContainsKey(continent))
                {
                    data.Add(continent, new Dictionary<string, List<string>>());
                    data[continent].Add(country, new List<string>());
                    data[continent][country].Add(city);
                }
                else
                {
                    if (!data[continent].ContainsKey(country))
                    {
                        data[continent].Add(country, new List<string>());
                        data[continent][country].Add(city);
                    }
                    else
                    {
                        data[continent][country].Add(city);
                    }
                }
            }

            foreach (var continent in data)
            {
                Console.WriteLine($"{continent.Key}");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> " + String.Join(", ", country.Value));
                }
            }
        }
    }
}
