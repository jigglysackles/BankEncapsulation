using System.Numerics;

namespace BankEncapsulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            //create account and set account numbers
            var bankAccount = new BankAccount();
            bankAccount.SetAccountNumberChecking("C123");
            bankAccount.SetAccountNumberSavings("S123");
            bool stop = false;
            var selection = "none";
            var menus = new Menu();

            Console.Clear();
            Console.WriteLine($"Welcome to my dinky ATM.");

            do
            {
                Console.WriteLine($"Please choose between Checking or Savings.");
                Console.WriteLine("For Checking press 1");
                Console.WriteLine("For Saving press 2");
                Console.WriteLine("To initiate a Transfer press 3");
                Console.WriteLine("To get your Balances press 4");
                var checkingOrSavings = Console.ReadKey();

                switch (checkingOrSavings.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        selection = "checking";
                        stop = true;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        selection = "savings";
                        stop = true;
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        selection = "transfers";
                        stop = true;
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        selection = "balances";
                        stop = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"You chose poorly. That's not valid, please try again.");
                        break;
                }
            } while (!stop);

            Console.Clear();

            //Checking
            if (selection == "checking")
            {
                var exitChecking = false;
                do
                {
                    menus.Checking();
                    var checkingMenuSelection = Console.ReadKey();

                    switch (checkingMenuSelection.Key)
                    {
                        //Deposits
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Console.Clear();

                            var exitDeposit = false;
                            do
                            {
                                Console.WriteLine($"Your balance currently {bankAccount.GetBalance()}");
                                Console.WriteLine($"How much would you like to deposit?");
                                var userAmount = Console.ReadLine();
                                if (!int.TryParse(userAmount, out var depositAmountInt))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid amount.");
                                }

                                if (depositAmountInt > 0)
                                {
                                    bankAccount.Deposit(depositAmountInt);
                                    Console.WriteLine($"Thank you! Your balance is now {bankAccount.GetBalance()}");
                                    exitDeposit = true;
                                }
                            } while (!exitDeposit);

                            break;

                        //Withdraws
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            Console.Clear();
                            var exitWithdraw = false;
                            do
                            {
                                Console.WriteLine($"Your balance currently {bankAccount.GetBalance()}");
                                Console.WriteLine($"How much would you like to withdraw?");
                                var userAmount = Console.ReadLine();
                                if (!int.TryParse(userAmount, out var withdrawAmountInt))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid amount.");
                                }

                                if (withdrawAmountInt > 0 && withdrawAmountInt <= bankAccount.GetBalance())
                                {
                                    bankAccount.Withdraw(withdrawAmountInt);
                                    Console.WriteLine($"Thank you! Your balance is now {bankAccount.GetBalance()}");
                                    exitWithdraw = true;
                                }

                                else
                                {
                                    Console.WriteLine(
                                        $"Your balance is {bankAccount.GetBalance()}. Please select a valid amount to withdraw.");
                                }
                            } while (!exitWithdraw);

                            break;

                        //Checking Account Balance
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            Console.Clear();
                            Console.WriteLine($"Your Checking Account balance is {bankAccount.GetBalance()}");
                            break;

                        //Exit
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            Console.Clear();
                            exitChecking = true;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine($"You chose poorly. That's not valid, please try again.");
                            break;
                    }
                } while (!exitChecking);
            }

            //Savings
            if (selection == "savings")
            {
                menus.Savings();
            }

            //Transfers
            if (selection == "transfers")
            {
                menus.Transfers();
            }

            //Balances
            if (selection == "balances")
            {
                Console.WriteLine("Balance selected!");
                Console.WriteLine($"Your Total Balance is {bankAccount.TotalBalance()}");
                Console.WriteLine($"Your Checking Balance is {bankAccount.GetBalance()}");
                Console.WriteLine($"Your Savings Balance is {bankAccount.GetBalanceSavings()}");
            }
        }
    }
}