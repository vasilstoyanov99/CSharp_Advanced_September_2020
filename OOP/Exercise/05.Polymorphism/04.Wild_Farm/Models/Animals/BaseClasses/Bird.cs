
using _04.Wild_Farm.Models.Animals.Contracts;

namespace _04.Wild_Farm.Models.Animals
{
    public abstract class Bird : Animal, IBird
    {
        public Bird(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]"; 
        }
    }
}
