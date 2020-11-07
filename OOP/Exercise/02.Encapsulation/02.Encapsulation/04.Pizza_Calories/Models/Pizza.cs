using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _04.Pizza_Calories.Models
{
    public class Pizza
    {
        private const string TOO_LONG_NAME_MSG = "Pizza name should be between 1 and 15 symbols.";
        private const string TOO_MUCH_TOPPINGS_MSG = "Number of toppings should be in range [0..10].";
        private string name;
        private Dough dough;
        private ICollection<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException(TOO_LONG_NAME_MSG);
                }

                name = value;
            }
        }

        public double TotalCalories
        {
            get
            {
                return ReturnTheTotalCalories();
            }
        }

        public Dough Dough
        {
            private get
            {
                return dough;
            }
            set
            {
                dough = value;
            }
        }

        public void AddTopping(Topping toAdd)
        {
            if (toppings.Count > 10)
            {
                throw new ArgumentException(TOO_MUCH_TOPPINGS_MSG);
            }

            toppings.Add(toAdd);
        }

        private double ReturnTheTotalCalories()
        {
            double result = 0.00;
            result += Dough.TotalCalories;

            foreach (var topping in toppings)
            {
                result += topping.TotalCalories;
            }

            return result;
        }
    }
}
