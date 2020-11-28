using System.Collections.Generic;

using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        private readonly List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }
    }
}
