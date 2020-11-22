
using _04.Wild_Farm.Global;

namespace _04.Wild_Farm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
            WeightGain = WeightGainFromFoods.OWL_WEIGHT_GAIN;
        }

        public override string AskForFood()
        {
            return AskForFoodSounds.OWL_ASK_FOR_FOOD_SOUND;
        }
    }
}
