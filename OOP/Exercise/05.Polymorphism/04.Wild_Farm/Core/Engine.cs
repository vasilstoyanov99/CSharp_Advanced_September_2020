using System;
using System.Collections.Generic;

using _04.Wild_Farm.Core.Contracts;
using _04.Wild_Farm.Factories;
using _04.Wild_Farm.Global;
using _04.Wild_Farm.Models.Animals;
using _04.Wild_Farm.Models.Foods;


namespace _04.Wild_Farm.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string input = Console.ReadLine();
            int inputLineCounter = default;
            List<Animal> animals = new List<Animal>();
            AnimalFactory animalFactory = new AnimalFactory();
            FoodFactory foodFactory = new FoodFactory();

            while (input != "End")
            {
                if (inputLineCounter % 2 == 0)
                {
                    string[] cmdArgs = input.Split(' ', '-', StringSplitOptions.RemoveEmptyEntries);
                    Animal newAnimal = animalFactory.CreateAnimal(cmdArgs);
                    Console.WriteLine(newAnimal.AskForFood());
                    animals.Add(newAnimal);
                }
                else
                {
                    string[] cmdArgs = input.Split(' ', '-', StringSplitOptions.RemoveEmptyEntries);
                    Food newFood = foodFactory.CreateFood(cmdArgs);
                    string animalType = animals[animals.Count - 1].GetType().Name;
                    string foodType = newFood.GetType().Name;
                    bool isNewFoodEatable = CheckIfFoodIsEatable(animalType, foodType);

                    if (!isNewFoodEatable)
                    {
                        Console.WriteLine(String.Format(Messages.DOES_NOT_EAT_THIS_TYPE_OF_FOOD,
                            animalType, foodType));
                    }
                    else
                    {
                        Animal animal = animals[animals.Count - 1];
                        double totalWeightGained = animal.WeightGain * newFood.Quantity;
                        animal.Weight += totalWeightGained;
                        animal.FoodEaten += newFood.Quantity;
                    }
                }

                inputLineCounter++;

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        public bool CheckIfFoodIsEatable(string animalType, string foodType)
        {
            switch (animalType)
            {
                case "Hen":
                    return true;
                case "Mouse":
                    switch (foodType)
                    {
                        case "Vegetable":
                        case "Fruit":
                            return true;
                        default:
                            return false;
                    }
                case "Cat":
                    switch (foodType)
                    {
                        case "Vegetable":
                        case "Meat":
                            return true;
                        default:
                            return false;
                    }
                case "Tiger":
                case "Dog":
                case "Owl":
                    switch (foodType)
                    {
                        case "Meat":
                            return true;
                        default:
                            return false;
                    }
            }

            return default;
        }
    }
}
