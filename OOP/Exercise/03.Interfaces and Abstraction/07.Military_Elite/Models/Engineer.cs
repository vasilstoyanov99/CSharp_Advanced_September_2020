using _07.Military_Elite.Contracts;

using System.Collections.Generic;
using System.Text;

namespace _07.Military_Elite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corpsArg)
            : base(id, firstName, lastName, salary, corpsArg)
        {
            repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)repairs;

        public void AddRepair(IRepair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                result.AppendLine($"  {repair.ToString()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
