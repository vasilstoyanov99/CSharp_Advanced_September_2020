using System;

namespace _03.Oldest_Family_Member
{
    public class Program
    {
        static void Main(string[] args)
        {
            int familyMembers = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < familyMembers; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);
                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
