
using _04.Wild_Farm.Factories.Contracts;
using _04.Wild_Farm.Models.Animals;

namespace _04.Wild_Farm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        private const int INITIAL_EATEN_FOOD = default;
        public Animal CreateAnimal(string[] cmdArgs)
        {
            string type = cmdArgs[0];
            string name = cmdArgs[1];
            double weight = double.Parse(cmdArgs[2]);
            Animal animal = null;

            if (cmdArgs.Length == 5)
            {
                string livingRegion = cmdArgs[3];
                string breed = cmdArgs[4];

                switch (type)
                {
                    case "Cat":
                        animal = new Cat(name, weight, INITIAL_EATEN_FOOD, livingRegion, breed);
                        break;
                    case "Tiger":
                        animal = new Tiger(name, weight, INITIAL_EATEN_FOOD, livingRegion, breed);
                        break;
                }
            }
            else if (type == "Mouse")
            {
                string livingRegion = cmdArgs[3];
                animal = new Mouse(name, weight, INITIAL_EATEN_FOOD, livingRegion);
            }
            else if (type == "Dog")
            {
                string livingRegion = cmdArgs[3];
                animal = new Dog(name, weight, INITIAL_EATEN_FOOD, livingRegion);
            }
            else if (cmdArgs.Length == 4)
            {
                double wingSize = double.Parse(cmdArgs[3]);

                switch (type)
                {
                    case "Owl":
                        animal = new Owl(name, weight, INITIAL_EATEN_FOOD, wingSize);
                        break;
                    case "Hen":
                        animal = new Hen(name, weight, INITIAL_EATEN_FOOD, wingSize);
                        break;
                }
            }

            return animal;
        }
    }
}
