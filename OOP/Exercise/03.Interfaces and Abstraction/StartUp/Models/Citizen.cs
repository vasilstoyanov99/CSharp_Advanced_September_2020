using StartUp.Contracts;
using System;

namespace StartUp
{
    public class Citizen : IIdentifieable, IBirthable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            Age = age;
            Name = name;
            ID = id;
            Birthday = birthday;
            Food = 0;
        }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public string ID { get; private set; }

        public string Birthday { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
