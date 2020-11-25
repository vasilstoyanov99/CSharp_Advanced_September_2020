using System.Collections.Generic;
using System.Text;

using _07.Military_Elite.Contracts;

namespace _07.Military_Elite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<ISoldier> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>)privates;

        public void AddPrivate(ISoldier @private)
        {
            privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine("Privates:");

            foreach (var soldier in privates)
            {
                result.AppendLine($"  {soldier.ToString()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
