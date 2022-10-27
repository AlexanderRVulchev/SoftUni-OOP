using System;
using System.Collections.Generic;
using System.Linq;
using PersonInfo.Interfaces;

namespace PersonInfo
{
    public class StationaryPhone : ICaller
    {
        public void Call(string number)
        {
            if (number.Any(ch => !char.IsDigit(ch)))
                Console.WriteLine("Invalid number!");
            else
                Console.WriteLine($"Dialing... {number}");
        }
    }
}