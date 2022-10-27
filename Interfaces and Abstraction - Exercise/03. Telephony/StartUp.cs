//You have a small business - manufacturing phones and to run your business you need to create phone software.
//The software should support two main phone models with the following functionality:
//•	Smartphone:
//•	Can calling other phones.
//•	Can browsing in the world wide web.
//•	Stationary phone:
//•	Can only call other phones.
//You should start the project by implementing two classes:
//•	The Smartphone can call other phones and browse the world wide web. 
//•	The StationaryPhone can only call other phones.
//You should also implement interfaces for each class with the appropriate methods.
//Input
//The input comes from the console. It will hold two lines:
//•	The First line consists of phone numbers: a string, separated by spaces.
//•	The Second line consists of websites: a string, separated by spaces.
//Output
//1.	First, call all valid numbers in the order of input:
//•	If there is a character different from a digit in a number, print:
//"Invalid number!" and continue with the next number.
//•	If the number is 10 digits long, you are making a call from your smartphone and print:
//"Calling... {number}"
//•	If the number is 7 digits long, you are making a call from your stationary phone and print:
//" Dialing... {number}"
//2.Next, browser all valid websites in the order of input:
//•	If there is a number in the input of the URLs,
//print: "Invalid URL!" and continue with the next URLs.
//•	If the URL is valid, print on the console the website in the format:
//"Browsing: {site}!"
//Constraints
//•	Each site's URL should consist only of letters and symbols
//(No digits are allowed in the URL address).
//•	The phone numbers will always be 7 or 10 digits long.


using System;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main()
        {
            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();
            string[] numbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();
            foreach (string number in numbers)
                if (number.Length == 7)
                    stationaryPhone.Call(number);
                else if (number.Length == 10)
                    smartphone.Call(number);

            foreach (string site in sites)
                smartphone.Browse(site);
        }
    }
}
