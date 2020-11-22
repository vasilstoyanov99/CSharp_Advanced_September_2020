
using _04.Wild_Farm.Models.Foods.Contracts;

namespace _04.Wild_Farm.Models.Foods
{
    public class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
