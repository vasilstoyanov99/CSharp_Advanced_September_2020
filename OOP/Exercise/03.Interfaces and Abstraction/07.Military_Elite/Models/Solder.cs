using _07.Military_Elite.Contracts;

namespace _07.Military_Elite.Models
{
    public abstract class Solder : ISoldier
    {
        protected Solder(int id, string firstName, string lastName)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int ID { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {ID}";
        }

    }
}
