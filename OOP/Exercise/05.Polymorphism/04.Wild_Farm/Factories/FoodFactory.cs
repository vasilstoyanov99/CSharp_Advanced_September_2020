
using _04.Wild_Farm.Factories.Contracts;
using _04.Wild_Farm.Models.Foods;
using _04.Wild_Farm.Models.Foods.Contracts;

namespace _04.Wild_Farm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public Food CreateFood(string[] cmdArgs)
        {
            string type = cmdArgs[0];
            int quantity = int.Parse(cmdArgs[1]);
            Food food = null;

            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "Fruit":
                    food = new Fruit(quantity);
                    break;
                case "Meat":
                    food = new Meat(quantity);
                    break;
                case "Seeds":
                    food = new Seeds(quantity);
                    break;
            }

            return food;
        }
    }
}
