using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp
{
    public class Citizen : IIdentifieable
    {
        public Citizen(string name, int age, string id)
        {
            Age = age;
            Name = name;
            ID = id;
        }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public string ID { get; private set; }
    }
}
