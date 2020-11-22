
using _04.Wild_Farm.Global;
using _04.Wild_Farm.Models.Animals.BaseClasses;

namespace _04.Wild_Farm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {
            WeightGain = WeightGainFromFoods.CAT_WEIGHT_GAIN;
        }

        public override string AskForFood()
        {
            return AskForFoodSounds.CAT_ASK_FOR_FOOD_SOUND;   
        }
    }
}
