using System.Collections.Generic;

namespace _07.Military_Elite.Contracts
{
    public interface ICommando : IPrivate
    {
        List<IMission> Missions { get; }
    }
}
