
using _04.Wild_Farm.Global;

namespace _04.Wild_Farm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {
            WeightGain = WeightGainFromFoods.MOUSE_WEIGHT_GAIN;
        }

        public override string AskForFood()
        {
            return AskForFoodSounds.MOUSE_ASK_FOR_FOOD_SOUND;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
