using System;
using System.Linq;
using System.Text;

using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;


namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverRepository;
        private RaceRepository raceRepository;
        private CarRepository carsRepository;

        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            raceRepository = new RaceRepository();
            carsRepository = new CarRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driverFromRepository = driverRepository.GetAll().FirstOrDefault(x => x.Name == driverName);

            if (driverFromRepository == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            ICar carFromRepository = carsRepository.GetAll().FirstOrDefault(x => x.Model == carModel);

            if (carFromRepository == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driverFromRepository.AddCar(carFromRepository);

            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace raceFromRepository = raceRepository.GetAll().FirstOrDefault(x => x.Name == raceName);

            if (raceFromRepository == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IDriver driverFromRepository = driverRepository.GetAll().FirstOrDefault(x => x.Name == driverName);

            if (driverFromRepository == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            raceFromRepository.AddDriver(driverFromRepository);
            return String.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car;
            ICar carFromRepository = carsRepository.GetAll().FirstOrDefault(x => x.Model == model);

            if (type == "Muscle")
            {
                if (carFromRepository != null)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
                }

                car = new MuscleCar(model, horsePower);
                carsRepository.Add(car);
            }
            else if (type == "Sports")
            {
                if (carFromRepository != null)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
                }

                car = new SportsCar(model, horsePower);
                carsRepository.Add(car);
            }

            return String.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driverFromRepository = driverRepository.GetAll()
                .FirstOrDefault(x => x.Name == driverName);

            if (driverFromRepository != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);
            driverRepository.Add(driver);
            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace raceFromRepository = raceRepository.GetAll().FirstOrDefault(x => x.Name == name);

            if (raceFromRepository != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            raceRepository.Add(race);
            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace raceFromRepository = raceRepository.GetAll().FirstOrDefault(x => x.Name == raceName);

            if (raceFromRepository == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (raceFromRepository.Drivers.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            int laps = raceFromRepository.Laps;

           IDriver[] result = driverRepository
                .GetAll()
                .OrderByDescending(x => x.Car.CalculateRacePoints(laps))
                .Take(3).ToArray();
            return CreateResult(result, raceName);
        }

        private string CreateResult(IDriver[] result, string raceName)
        {
            StringBuilder toReturn = new StringBuilder();
            toReturn.AppendLine(String.Format(OutputMessages.DriverFirstPosition, result[0].Name, raceName));
            toReturn.AppendLine(String.Format(OutputMessages.DriverSecondPosition, result[1].Name, raceName));
            toReturn.AppendLine(String.Format(OutputMessages.DriverThirdPosition, result[2].Name, raceName));
            return toReturn.ToString().TrimEnd();
        }
    }
}
