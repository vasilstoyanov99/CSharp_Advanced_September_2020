using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Shopping_Spree
{
    public class Product
    {
        private string name;
        private double cost;

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

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
                if (value < 0)
                {
                    throw new ArgumentException("Cost cannot be negative");
                }

                cost = value;
            }
        }

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
