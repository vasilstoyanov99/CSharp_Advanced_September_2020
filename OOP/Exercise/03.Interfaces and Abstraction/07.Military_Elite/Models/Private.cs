using _07.Military_Elite.Contracts;

namespace _07.Military_Elite.Models
{
    public class Private : Solder, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {Salary:f2}"; 
        }
    }
}
