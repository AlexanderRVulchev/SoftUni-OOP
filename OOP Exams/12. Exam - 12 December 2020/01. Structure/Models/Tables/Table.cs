using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    using Models.BakedFoods.Contracts;
    using Models.Drinks;
    using Models.Drinks.Contracts;
    using Models.Tables.Contracts;
    using Utilities.Messages;

    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private bool isReserved;
        private decimal pricePerPerson;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }

        public int TableNumber
        {
            get { return tableNumber; }
            private set { tableNumber = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get { return pricePerPerson; }
            private set { pricePerPerson = value; }
        }

        public bool IsReserved
        {
            get { return isReserved; }
            private set { isReserved = value; }
        }

        public decimal Price => PricePerPerson * NumberOfPeople;

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            IsReserved = false;
            numberOfPeople = 0;
        }

        public decimal GetBill()
        => foodOrders.Sum(x => x.Price) + drinkOrders.Sum(x => x.Price);

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.Append($"Price per Person: {PricePerPerson}");
            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
