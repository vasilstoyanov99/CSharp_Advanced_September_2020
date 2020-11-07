using _04.Pizza_Calories.Models;
using System;

namespace _04.Pizza_Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine().Split();
                Pizza pizza = new Pizza(pizzaInput[1]);
                string[] doughInput = Console.ReadLine().Split();
                Dough dough = new Dough(doughInput[1], doughInput[2], int.Parse(doughInput[3]));
                pizza.Dough = dough;
                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] toppingInput = input.Split();
                    Topping topping = new Topping(toppingInput[1], int.Parse(toppingInput[2]));
                    pizza.AddTopping(topping);
                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
