//You will receive on the first line a collection of bank accounts,
//consisting of an account number (integer) and its balance (double), in the following format:
//"{account number}-{account balance},{account number}-{account balance},…"
// After that, until the "End" command, you will receive commands,
// which should manipulate the given account`s balance:
//•	"Deposit {account number} {sum}" – Add the given sum to the given account`s balance. 
//•	"Withdraw {account number} {sum}" – Subtract the given sum from the account`s balance.
//Print the following messages from the exceptions which can be produced from your program:
//•	If you receive an invalid command:
//"Invalid command!"
//•	If you receive an account, which does not exist:
//"Invalid account!"
//•	If you receive the "Withdraw" command with the sum, which is bigger than the balance:
//"Insufficient balance!"
//In all cases, after each received command, print the message:
//	"Enter another command"
//After each successful operation print,
//the new balance is formatted to the second integer after the decimal point:
//	"Account {account number} has new balance: {balance}"


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _06._Money_Transactions
{
    internal class Program
    {            
        static void Main()
        {
            var accountBalances = new Dictionary<int, double>();
            string[] tokens = Console.ReadLine().Split(',');
            for (int i = 0; i < tokens.Length; i++)
            {
                int account = int.Parse(tokens[i].Split('-').First());
                double balance = double.Parse(tokens[i].Split('-').Last());
                accountBalances.Add(account, balance);
            }
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] cmd = input.Split();
                    string command = cmd[0];
                    if (command != "Deposit" && command != "Withdraw")
                        throw new ArgumentException("Invalid command!");

                    int account;
                    try
                    {
                        account = int.Parse(cmd[1]);
                        if (!accountBalances.Keys.Contains(account))
                            throw new FormatException();
                    }
                    catch (FormatException)
                    { throw new ArgumentException("Invalid account!"); }

                    double money = double.Parse(cmd[2]);
                    if (command == "Deposit") accountBalances[account] += money;
                    else if (command == "Withdraw")
                    {
                        if (money > accountBalances[account])
                            throw new ArgumentException("Insufficient balance!");
                        accountBalances[account] -= money;
                    }

                    Console.WriteLine($"Account {account} has new balance: {accountBalances[account]:f2}");
                }
                catch (ArgumentException ex)
                { Console.WriteLine(ex.Message); }
                Console.WriteLine("Enter another command");                
            }
        }
    }
}