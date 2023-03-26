using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal InitialPricePerPerson = 3.50M;

        public OutsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }
    }
}
