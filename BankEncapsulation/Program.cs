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
            bool quit = false;
            bool stop = false;
            var selection = "none";
            var menus = new Menu();

            do
            {
                Console.Clear();
                Console.WriteLine($"Welcome to my dinky ATM.");

                do
                {
                    menus.Welcome();
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

                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            stop = true;
                            quit = true;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine($"You chose poorly. That's not valid, please try again.");
                            break;
                    }
                } while (!stop);

                Console.Clear();

                //Checking

                #region CHECKING

                if (selection == "checking")
                {
                    selection = "none";
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
                                    if (!double.TryParse(userAmount, out var depositAmountDbl))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter a valid amount.");
                                    }

                                    if (depositAmountDbl > 0)
                                    {
                                        bankAccount.Deposit(depositAmountDbl);
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
                                    if (!double.TryParse(userAmount, out var withdrawAmountDbl))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter a valid amount.");
                                    }

                                    if (withdrawAmountDbl > 0 && withdrawAmountDbl <= bankAccount.GetBalance())
                                    {
                                        bankAccount.Withdraw(withdrawAmountDbl);
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

                #endregion

                //Savings

                #region SAVINGS

                if (selection == "savings")
                {
                    selection = "none";
                    var exitSavings = false;
                    do
                    {
                        menus.Savings();
                        var savingsMenuSelection = Console.ReadKey();

                        switch (savingsMenuSelection.Key)
                        {
                            //Deposits
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                Console.Clear();

                                var exitDepositSavings = false;
                                do
                                {
                                    Console.WriteLine($"Your balance currently {bankAccount.GetBalanceSavings()}");
                                    Console.WriteLine($"How much would you like to deposit?");
                                    var userAmount = Console.ReadLine();
                                    if (!double.TryParse(userAmount, out var depositAmountDbl))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter a valid amount.");
                                    }

                                    if (depositAmountDbl > 0)
                                    {
                                        bankAccount.DepositSavings(depositAmountDbl);
                                        Console.WriteLine(
                                            $"Thank you! Your balance is now {bankAccount.GetBalanceSavings()}");
                                        exitDepositSavings = true;
                                    }
                                } while (!exitDepositSavings);

                                break;

                            //Withdraws
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                Console.Clear();
                                var exitWithdrawSavings = false;
                                do
                                {
                                    Console.WriteLine($"Your balance currently {bankAccount.GetBalanceSavings()}");
                                    Console.WriteLine($"How much would you like to withdraw?");
                                    var userAmount = Console.ReadLine();
                                    if (!double.TryParse(userAmount, out var withdrawAmountDbl))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter a valid amount.");
                                    }

                                    if (withdrawAmountDbl > 0 && withdrawAmountDbl <= bankAccount.GetBalanceSavings())
                                    {
                                        bankAccount.WithdrawSavings(withdrawAmountDbl);
                                        Console.WriteLine(
                                            $"Thank you! Your balance is now {bankAccount.GetBalanceSavings()}");
                                        exitWithdrawSavings = true;
                                    }

                                    else
                                    {
                                        Console.WriteLine(
                                            $"Your balance is {bankAccount.GetBalanceSavings()}. Please select a valid amount to withdraw.");
                                    }
                                } while (!exitWithdrawSavings);

                                break;

                            //Checking Account Balance
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Console.Clear();
                                Console.WriteLine($"Your Savings Account balance is {bankAccount.GetBalanceSavings()}");
                                break;

                            //Exit
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.Clear();
                                exitSavings = true;
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine($"You chose poorly. That's not valid, please try again.");
                                break;
                        }
                    } while (!exitSavings);
                }

                #endregion

                //Balances

                #region BALANCES

                if (selection == "balances")
                {
                    Console.WriteLine("Balance selected!");
                    Console.WriteLine($"Your Total Balance is {bankAccount.TotalBalance()}");
                    Console.WriteLine($"Your Checking Balance is {bankAccount.GetBalance()}");
                    Console.WriteLine($"Your Savings Balance is {bankAccount.GetBalanceSavings()}");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    selection = "none";
                }

                #endregion

                //Transfers

                #region TRANSFERS

                if (selection == "transfers")
                {
                    selection = "none";
                    var exitTransfers = false;
                    do
                    {
                        menus.Transfers();
                        var savingsMenuSelection = Console.ReadKey();

                        switch (savingsMenuSelection.Key)
                        {
                            //Transfer from Checking
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                Console.Clear();
                                Console.WriteLine($"Your Checking Account balance is {bankAccount.GetBalance()}");
                                var exitTransChecking = false;
                                do
                                {
                                    Console.WriteLine($"How much would you like to transfer?");
                                    var userAmountToTransferFromChecking = Console.ReadLine();
                                    if (!double.TryParse(userAmountToTransferFromChecking, out var transferAmountDbl))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter a valid amount.");
                                    }

                                    if (transferAmountDbl > 0 && transferAmountDbl <= bankAccount.GetBalance())
                                    {
                                        bankAccount.TransferFromChecking(transferAmountDbl);
                                        Console.WriteLine("Transfer successful!");
                                        Console.WriteLine("New Balances:");
                                        Console.WriteLine($"Checking: {bankAccount.GetBalance()}");
                                        Console.WriteLine($"Savings: {bankAccount.GetBalanceSavings()}");
                                        Console.WriteLine($"Total Balance: {bankAccount.TotalBalance()}");
                                        exitTransChecking = true;
                                    }

                                    else
                                    {
                                        Console.WriteLine("Incorrect input or insufficient funds.");
                                        Console.WriteLine("Press Enter to continue.");
                                        Console.ReadLine();
                                        exitTransChecking = true;
                                    }
                                } while (!exitTransChecking);

                                break;

                            //Transfer from Savings
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                Console.Clear();
                                Console.WriteLine($"Your Savings Account balance is {bankAccount.GetBalanceSavings()}");
                                var exitTransSavings = false;
                                do
                                {
                                    Console.WriteLine($"How much would you like to transfer?");
                                    var userAmountToTransferFromSavings = Console.ReadLine();
                                    if (!double.TryParse(userAmountToTransferFromSavings, out var transferAmountDbl))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please enter a valid amount.");
                                    }

                                    if (transferAmountDbl > 0 && transferAmountDbl <= bankAccount.GetBalance())
                                    {
                                        bankAccount.TransferFromSavings(transferAmountDbl);
                                        Console.WriteLine("Transfer successful!");
                                        Console.WriteLine("New Balances:");
                                        Console.WriteLine($"Savings: {bankAccount.GetBalanceSavings()}");
                                        Console.WriteLine($"Checking: {bankAccount.GetBalance()}");
                                        Console.WriteLine($"Total Balance: {bankAccount.TotalBalance()}");
                                        exitTransSavings = true;
                                    }
                                    
                                    else
                                    {
                                        Console.WriteLine("Incorrect input or insufficient funds.");
                                        Console.WriteLine("Press Enter to continue.");
                                        Console.ReadLine();
                                        exitTransSavings = true;
                                    }
                                } while (!exitTransSavings);

                                break;

                            //Verify Balances
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                Console.Clear();
                                Console.WriteLine($"Your Checking Account balance is {bankAccount.GetBalance()}");
                                Console.WriteLine($"Your Savings Account balance is {bankAccount.GetBalanceSavings()}");
                                Console.WriteLine($"Your total account balance is  {bankAccount.TotalBalance()}");
                                break;

                            //Exit
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                Console.Clear();
                                exitTransfers = true;
                                break;
                        }
                    } while (!exitTransfers);
                }

                #endregion
            } while (!quit);
        }
    }
}