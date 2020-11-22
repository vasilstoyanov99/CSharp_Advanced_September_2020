using System;

using _03.Raiding.Contracts;
using _03.Raiding.Global;

namespace _03.Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name)
            : base(name)
        {

        }

        public override int Power => HeroesPowers.DRUID_AND_ROGUE_POWER;

        public override string CastAbility()
        {
            return String.Format(CastAbilityOverrides.ROGUE_AND_WARRIOR_RETURN,
                GetType().Name, Name, Power);
        }
    }
}
