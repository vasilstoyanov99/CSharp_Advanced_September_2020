using System.Collections.Generic;

using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        private readonly List<IDriver> drivers;

        public DriverRepository()
        {
            drivers = new List<IDriver>();
        }
    }
}
