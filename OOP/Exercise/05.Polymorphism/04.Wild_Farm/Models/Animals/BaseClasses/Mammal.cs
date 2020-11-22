
using _04.Wild_Farm.Models.Animals.Contracts;

namespace _04.Wild_Farm.Models.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        public Mammal(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }
    }
}
