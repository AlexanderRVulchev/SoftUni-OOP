using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Core
{
    using Bakery.Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables;
    using Bakery.Models.Tables.Contracts;
    using Contracts;
    using System.Linq;
    using Utilities.Messages;

    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal income;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            switch (type)
            {
                case "Tea": drink = new Tea(name, portion, brand); break;
                case "Water": drink = new Water(name, portion, brand); break;
            }
            drinks.Add(drink);
            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            switch (type)
            {
                case "Bread": food = new Bread(name, price); break;
                case "Cake": food = new Cake(name, price); break;
            }
            bakedFoods.Add(food);
            return String.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            switch (type)
            {
                case "InsideTable": table = new InsideTable(tableNumber, capacity); break;
                case "OutsideTable": table = new OutsideTable(tableNumber, capacity); break;
            }
            tables.Add(table);
            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        => String.Join(Environment.NewLine, tables.Where(x => !x.IsReserved).Select(x => x.GetFreeTableInfo()));

        public string GetTotalIncome()
        => $"Total income: {income}lv";

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.Find(x => x.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            table.Clear();
            income += bill;
            return $"Table: {tableNumber}" + Environment.NewLine +
                   $"Bill: {bill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.Find(x => x.TableNumber == tableNumber);
            IDrink drink = drinks.Find(x => x.Name == drinkName && x.Brand == drinkBrand);
            if (table == null)
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            if (drink == null)
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.Find(x => x.TableNumber == tableNumber);
            IBakedFood food = bakedFoods.Find(x => x.Name == foodName);
            if (table == null)
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            if (food == null)
                return String.Format(OutputMessages.NonExistentFood, foodName);
            table.OrderFood(food);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.Find(x => !x.IsReserved && x.Capacity >= numberOfPeople);
            if (table == null)
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            table.Reserve(numberOfPeople);
            return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}
