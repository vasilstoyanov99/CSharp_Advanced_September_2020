
using _04.Wild_Farm.Global;
using _04.Wild_Farm.Models.Animals.BaseClasses;

namespace _04.Wild_Farm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {
            WeightGain = WeightGainFromFoods.TIGER_WEIGHT_GAIN;
        }

        public override string AskForFood()
        {
            return AskForFoodSounds.TIGER_ASK_FOR_FOOD_SOUND;
        }
    }
}
