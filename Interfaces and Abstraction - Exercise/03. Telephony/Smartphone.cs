using System;
using System.Linq;
using PersonInfo.Interfaces;

namespace PersonInfo
{
    public class Smartphone : ICaller, IBrowser
    {
        public void Browse(string site)
        {
            if (site.Any(ch => char.IsDigit(ch)))
                Console.WriteLine("Invalid URL!");
            else
                Console.WriteLine($"Browsing: {site}!");
        }

        public void Call(string number)
        {
            if (number.Any(ch => !char.IsDigit(ch)))
                Console.WriteLine("Invalid number!");
            else
                Console.WriteLine($"Calling... {number}");
        }
    }
}
