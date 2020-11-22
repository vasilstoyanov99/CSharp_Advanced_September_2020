
using _04.Wild_Farm.Models.Foods;

namespace _04.Wild_Farm.Factories.Contracts
{
    public interface IFoodFactory
    {
        Food CreateFood(string[] cmdArgs);
    }
}
