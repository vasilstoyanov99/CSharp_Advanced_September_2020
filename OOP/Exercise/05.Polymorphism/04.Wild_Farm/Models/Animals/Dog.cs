
using _04.Wild_Farm.Global;

namespace _04.Wild_Farm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {
            WeightGain = WeightGainFromFoods.DOG_WEIGHT_GAIN;
        }

        public override string AskForFood()
        {
            return AskForFoodSounds.DOG_ASK_FOR_FOOD_SOUND;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
