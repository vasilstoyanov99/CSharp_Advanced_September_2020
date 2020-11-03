using System;
using System.Collections.Generic;
using System.Text;
using _03.Shopping_Spree.Models;

namespace _03.Shopping_Spree
{
    public class Person
    {
        private string name;
        private double money;
        private ICollection<string> bagOfProducts;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<string>();
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

        public double Money
        {
            get
            {
                return money;
            }
            private set
            {
                Validators.CheckValue(value, nameof(Money));
                money = value;
            }
        }

        public void CheckIfPersonCanBuy(Product product)
        {
            if (product.Cost <= Money)
            {
                bagOfProducts.Add(product.Name);
                money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (bagOfProducts.Count > 0)
            {
                return String.Join(", ", bagOfProducts);
            }
            else
            {
                return "Nothing bought";
            }
        }
    }
}
