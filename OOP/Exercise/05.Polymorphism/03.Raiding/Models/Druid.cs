using System;

using _03.Raiding.Contracts;
using _03.Raiding.Global;

namespace _03.Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name)
            : base(name)
        {

        }

        public override int Power => HeroesPowers.DRUID_AND_ROGUE_POWER;

        public override string CastAbility()
        {
            return String.Format(CastAbilityOverrides.DRUID_AND_PALADIN_RETURN,
                GetType().Name, Name, Power);
        }
    }
}
