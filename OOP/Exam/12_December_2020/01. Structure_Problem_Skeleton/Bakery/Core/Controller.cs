using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.BakedFoods.Models;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Drinks.Models;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.Tables.Models;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food;

            if (type == "Bread")
            {
                food = new Bread(name, price);
                bakedFoods.Add(food);
                return String.Format(OutputMessages.FoodAdded, name, type);
            }
            else
            {
                food = new Cake(name, price);
                bakedFoods.Add(food);
                return String.Format(OutputMessages.FoodAdded, name, type);
            }
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
                Drink drink;

                if (type == "Tea")
                {
                    drink = new Tea(name, portion, brand);
                        drinks.Add(drink);
                        return String.Format(OutputMessages.DrinkAdded, name, brand);
                }
                else
                {
                    drink = new Water(name, portion, brand);
                    drinks.Add(drink);
                    return String.Format(OutputMessages.DrinkAdded, name, brand);
                }

        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table;

                if (type == "InsideTable")
                {
                    table = new InsideTable(tableNumber, capacity);
                    tables.Add(table);
                    return String.Format(OutputMessages.TableAdded, tableNumber);
                }
                else
                {
                    table = new OutsideTable(tableNumber, capacity);
                    tables.Add(table);
                    return String.Format(OutputMessages.TableAdded, tableNumber);
                }
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable freeTable = tables
                .FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);

            if (freeTable is null)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                freeTable.Reserve(numberOfPeople);
                return String.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table is null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (food is null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            
            if (table is null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IDrink drink = drinks.FirstOrDefault
                (x => x.Name == drinkName && x.Brand == drinkBrand);

            if (drink is null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Table: {tableNumber}");
            result.AppendLine($"Bill: {table.GetBill():f2}");
            totalIncome += table.GetBill();
            table.Clear();
            return result.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> allFreeTables = tables.Where(x => x.IsReserved == false).ToList();
            StringBuilder result = new StringBuilder();

            foreach (var freeTable in allFreeTables)
            {
                result.AppendLine(freeTable.GetFreeTableInfo().Trim());
            }

            return result.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            if (tables.Any(x => x.IsReserved == true))
            {
                foreach (var table in tables.Where(x => x.IsReserved == true))
                {
                    totalIncome += table.GetBill();
                }
            }

            return String.Format(OutputMessages.TotalIncome, totalIncome);
        }
    }
}
