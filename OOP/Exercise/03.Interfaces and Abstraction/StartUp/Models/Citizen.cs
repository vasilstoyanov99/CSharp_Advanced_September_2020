using StartUp.Contracts;
using System;

namespace StartUp
{
    public class Citizen : IIdentifieable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            Age = age;
            Name = name;
            ID = id;
            Birthday = birthday;
        }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public string ID { get; private set; }

        public string Birthday { get; private set; }
    }
}
