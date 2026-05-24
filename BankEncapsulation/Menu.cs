namespace BankEncapsulation;

using System;

public class Menu
{
    public void Checking()
    {
        Console.WriteLine("\nChecking is selected!");
        Console.WriteLine("What would you like to do now?");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Get Balance");
        Console.WriteLine("4. Exit");
    }

    public void Savings()
    {
        Console.WriteLine("\nSavings is selected!");
        Console.WriteLine("What would you like to do now?");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Get Balance");
        Console.WriteLine("4. Exit");
    }

    public void Transfers()
    {
        Console.WriteLine("\nTransfers is selected!");
        Console.WriteLine("Which account do you want to transfer from?");
        Console.WriteLine("1. Checking");
        Console.WriteLine("2. Savings");
        Console.WriteLine("3. Exit");
    }
}