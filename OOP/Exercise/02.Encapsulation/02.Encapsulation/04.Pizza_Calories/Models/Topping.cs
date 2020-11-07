using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Pizza_Calories.Models
{
    public class Topping
    {
        private const double BASE_CALORIES_PER_GRAM = 2.00;
        private const string INVALID_TOPPING_MSG = "Cannot place {0} on top of your pizza.";
        private const string INVALID_WEIGHT_MSG = "{0} weight should be in the range[1..50].";
        private string type;
        private int weight;
        private double totalCalories;

        public Topping(string toppingTypeInput, int weightInput)
        {
            Type = toppingTypeInput;
            Weight = weightInput;
            TotalCalories = BASE_CALORIES_PER_GRAM;
        }

        private string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (!CheckIfToppingIsValid(value))
                {
                    throw new ArgumentException(String.Format(INVALID_TOPPING_MSG, value));
                }

                type = value;
            }
        }

        private int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (!CheckIfWeightIsValid(value))
                {
                    throw new ArgumentException(String.Format(INVALID_WEIGHT_MSG, Type));
                }

                weight = value;
            }
        }

        public double TotalCalories 
        {
            get
            {
                return totalCalories;
            }
            private set 
            {
                double additionalCaloriesPerGram = ReturnToppingCaloriesPerGram();
                totalCalories = (weight * value) * additionalCaloriesPerGram;
            }
        }

        private double ReturnToppingCaloriesPerGram()
        {
            string copy = Type.ToLower();

            if (copy == "meat")
            {
                return 1.20;
            }
            else if (copy == "veggies")
            {
                return 0.80;
            }
            else if (copy == "cheese")
            {
                return 1.10;
            }
            else
            {
                return 0.90;
            }
        }


        private bool CheckIfToppingIsValid(string value)
        {
            value = value.ToLower();

            return value == "sauce" || value == "cheese" || value == "veggies" || value == "meat";
        }

        private bool CheckIfWeightIsValid(int value)
        {
            return value >= 1 && value <= 50;
        }

    }
}
