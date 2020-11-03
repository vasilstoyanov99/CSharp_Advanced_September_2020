using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Shopping_Spree
{
    public class Person
    {
        private string name;
        private double money;
        private List<string> bagOfProducts;

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

        public double Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<string>();
        }
    }
}
