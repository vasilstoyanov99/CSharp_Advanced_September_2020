using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public string Name { get; private set; }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get
            {
                return firstTeam.AsReadOnly();
            }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get
            {
                return reserveTeam.AsReadOnly();
            }
        }

        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
