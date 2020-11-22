
using _04.Wild_Farm.Global;

namespace _04.Wild_Farm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
            WeightGain = WeightGainFromFoods.HEN_WEIGHT_GAIN;
        }

        public override string AskForFood()
        {
            return AskForFoodSounds.HEN_ASK_FOR_FOOD_SOUND;
        }
    }
}
