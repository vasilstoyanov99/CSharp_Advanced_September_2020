using System.Collections.Generic;
using System.Text;

using _07.Military_Elite.Contracts;

namespace _07.Military_Elite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corpsArg)
            : base(id, firstName, lastName, salary, corpsArg)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)missions;

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                result.AppendLine($"  {mission.ToString()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
