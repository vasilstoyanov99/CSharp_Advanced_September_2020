﻿using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person();
            Person secondPerson = new Person(20);
            Person thirdPerson = new Person("Stamat", 43);

            Console.WriteLine($"Name: {firstPerson.Name}, Age: {firstPerson.Age}");
            Console.WriteLine($"Name: {secondPerson.Name}, Age: {secondPerson.Age}");
            Console.WriteLine($"Name: {thirdPerson.Name}, Age: {thirdPerson.Age}");
        }
    }
}
