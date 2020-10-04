using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05.Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            Person[] peopleData = new Person[numberOfLines];

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] data = Console.ReadLine().Split(", ");
                string name = data[0];
                int age = int.Parse(data[1]);
                peopleData[i] = new Person(name, age);
            }

            string condition = Console.ReadLine();
            int ageToSort = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<Person, bool> conditionDelegate = SortBy(condition, ageToSort);
            Action<Person> printerDelegate = PrintResults(format);

            foreach (var person in peopleData)
            {
                if (conditionDelegate(person))
                {
                    printerDelegate(person);
                }
            }

        }

        static Func<Person, bool> SortBy(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return p => p.Age < age;
                case "older":
                    return p => p.Age >= age;
                default:
                    return null;
            }
        }

        static Action<Person> PrintResults(string format)
        {
            switch (format)
            {
                case "name":
                    return p => Console.WriteLine($"{p.Name}");
                case "age":
                    return p => Console.WriteLine($"{p.Age}");
                case "name age":
                    return p => Console.WriteLine($"{p.Name} - {p.Age}");
                default:
                    return null;
            }
        } 
    }

    class Person
    {
       public string Name { get; set; }
       public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
