using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables.Models
{
    public abstract class Table : ITable
    {
        private int _capacity;
        private int _numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            FoodOrders = new List<IBakedFood>();
            DrinkOrders = new List<IDrink>();
        }

        private List<IBakedFood> FoodOrders { get; }

        private List<IDrink> DrinkOrders { get; }

        public int TableNumber { get; }

        public int Capacity
        {
            get => _capacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                _capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => _numberOfPeople;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                _numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => PricePerPerson * NumberOfPeople;

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }

        public void OrderFood(IBakedFood food)
        {
            FoodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal bill = FoodOrders.Sum(x => x.Price)
                           + DrinkOrders.Sum(x => x.Price)
                           + Price;
            return bill;
        }

        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();
            IsReserved = false;
            NumberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Table: {TableNumber}");
            result.AppendLine($"Type: {GetType().Name}");
            result.AppendLine($"Capacity: {Capacity}");
            result.AppendLine($"Price per Person: {PricePerPerson:F2}"); 
            return result.ToString().Trim();
        }
    }
}
