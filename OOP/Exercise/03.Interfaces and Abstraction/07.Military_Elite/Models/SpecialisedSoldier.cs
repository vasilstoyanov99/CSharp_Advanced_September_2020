using System;

using _07.Military_Elite.Contracts;
using _07.Military_Elite.Exceptions;
using _07.Military_Elite.Global;


namespace _07.Military_Elite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corpsArg)
            : base(id, firstName, lastName, salary)
        {
            Corps = TryParseCorps(corpsArg);
        }

        public CorpsTypes Corps { get; private set; }

        private CorpsTypes TryParseCorps(string corpsArg)
        {
            CorpsTypes corps;

            bool isParsed = Enum.TryParse<CorpsTypes>(corpsArg, out corps);

            if (!isParsed)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {Corps.ToString()}";
        }
    }
}
