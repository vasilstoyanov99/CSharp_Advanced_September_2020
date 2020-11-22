
namespace _04.Wild_Farm.Models.Animals.Contracts
{
    public interface IAnimal
    {
        public string Name { get; }

        public double Weight { get; }

        public int FoodEaten { get; }

        public double WeightGain { get; }
    }
}
