

namespace _03.Raiding.Contracts
{
    interface IBaseHero
    {
        public string Name { get; }

        public int Power { get; }

        string CastAbility();
    }
}
