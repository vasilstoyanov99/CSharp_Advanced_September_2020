using System;
using System.Collections.Generic;

namespace _05.Comparing_Objects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> allPeople = new List<Person>();

            while (input != "END")
            {
                string[] personData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personData[0];
                int age = int.Parse(personData[1]);
                string town = personData[2];
                Person person = new Person(name, age, town);
                allPeople.Add(person);
                input = Console.ReadLine();
            }

            int number = int.Parse(Console.ReadLine());
            Person toBeCompared = allPeople[number - 1];
            int samePeopleCounter = 0;

            foreach (var person in allPeople)
            {
                if (person.CompareTo(toBeCompared) == 0)
                {
                    samePeopleCounter++;
                }
            }

            if (samePeopleCounter == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{samePeopleCounter} {allPeople.Count - samePeopleCounter} {allPeople.Count}");
            }
        }
    }
}
