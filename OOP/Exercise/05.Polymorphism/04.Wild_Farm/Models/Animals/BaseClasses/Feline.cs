
using _04.Wild_Farm.Models.Animals.Contracts;

namespace _04.Wild_Farm.Models.Animals.BaseClasses
{
    public abstract class Feline : Mammal, IFeline
    {
        public Feline(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion)
        {
            Breed = breed;
        }
        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
