using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Opinion_Poll
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);
                Person person = new Person(name, age);
                people.Add(person);
            }

            List<Person> sorted = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();

            foreach (var person in sorted)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
