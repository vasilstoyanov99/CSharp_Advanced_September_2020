using _07.Military_Elite.Global;

namespace _07.Military_Elite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public CorpsTypes Corps { get; }
    }
}
