using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Pizza_Calories.Models
{
    public class Dough
    {
        private const double BASE_DOUGH_CAL_PER_GRAM = 2.00;
        private const string INVALID_FLOUR_TYPE_MSG = "Invalid type of dough.";
        private const string INVALID_DOUGH_WEIGHT_MSG = "Dough weight should be in the range [1..200].";
        private string flourType;
        private int weight;
        private double totalCalories;

        public Dough(string flourTypeInput, string bakingTechniqueInput, int weightInput)
        {
            FlourType = flourTypeInput;
            Weight = weightInput;
            BakingTechnique = bakingTechniqueInput;
            TotalCalories = BASE_DOUGH_CAL_PER_GRAM;
        }

        private string FlourType 
        {
            get
            {
                return flourType;
            }
            set
            {
                if (!CheckIfFlourTypeIsValid(value))
                {
                    throw new ArgumentException(INVALID_FLOUR_TYPE_MSG);
                }

                flourType = value;
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
                if (!CheckIDoughWeightIsValid(value))
                {
                    throw new ArgumentException(INVALID_DOUGH_WEIGHT_MSG);
                }

                weight = value;
            }
        }

        private string BakingTechnique { get; set; }

        public double TotalCalories 
        { 
            get 
            {
                return totalCalories;
            }
            private set 
            {
                double caloriesFromFlourType = ReturnFlourTypeCaloriesPerGram(FlourType);
                double caloriesFromBakingTechnique = ReturnBakingTechniqueCaloriesPerGram(BakingTechnique);
                totalCalories = (value * Weight) * caloriesFromFlourType * caloriesFromBakingTechnique; 
            }
        }

        private bool CheckIfFlourTypeIsValid(string value)
        {
            value = value.ToLower();
            return value == "white" || value == "wholegrain";
        }

        private bool CheckIDoughWeightIsValid(int value)
        {
            return value >= 1 && value <= 200;
        }

        private double ReturnFlourTypeCaloriesPerGram(string flourType)
        {
            flourType = flourType.ToLower();

            if (flourType == "white")
            {
                return 1.50;
            }
            else
            {
                return 1.00;
            }
        }

        private double ReturnBakingTechniqueCaloriesPerGram(string bakingTechnique)
        {
            bakingTechnique = bakingTechnique.ToLower();

            if (bakingTechnique == "crispy")
            {
                return 0.90;
            }
            else if (bakingTechnique == "chewy")
            {
                return 1.10;
            }
            else
            {
                return 1.00;
            }
        }
    }
}
