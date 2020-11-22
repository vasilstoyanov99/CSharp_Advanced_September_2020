
using _04.Wild_Farm.Models.Animals;

namespace _04.Wild_Farm.Factories.Contracts
{
     public interface IAnimalFactory
    {
        Animal CreateAnimal(string[] cmdArgs);
    }
}
