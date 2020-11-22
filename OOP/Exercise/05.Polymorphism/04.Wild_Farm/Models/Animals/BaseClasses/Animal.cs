
using _04.Wild_Farm.Models.Animals.Contracts;

namespace _04.Wild_Farm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get; private set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public double WeightGain { get; protected set; }

        public virtual string AskForFood()
        {
            return null;
        }
    }
}
