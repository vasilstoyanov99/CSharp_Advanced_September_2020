using _03.Shopping_Spree.Models;

namespace _03.Shopping_Spree
{
    public class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                Validators.CheckName(value);
                name = value;
            }
        }

        public double Cost
        {
            get
            {
                return cost;
            }
            private set
            {
                Validators.CheckValue(value, nameof(Cost));
                cost = value;
            }
        }
    }
}
