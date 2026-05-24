namespace BankEncapsulation;

public class BankAccount
{
    //properites
    private string AccountNumberChecking { get; set; }
    private string AccountNumberSavings { get; set; }


    //fields
    private double _balance = 0;
    private double _balanceSavings = 0;


    //methods
    public void SetAccountNumberChecking(string accountNumber)
    {
        AccountNumberChecking = accountNumber;
    }

    public void SetAccountNumberSavings(string accountNumber)
    {
        AccountNumberSavings = accountNumber;
    }

    public void Deposit(double amountToDeposit)
    {
        _balance += amountToDeposit;
    }

    public void DepositSavings(double amountToDeposit)
    {
        _balanceSavings += amountToDeposit;
    }

    public void Withdraw(double amountToWithdraw)
    {
        if (_balance > amountToWithdraw)
        {
            _balance -= amountToWithdraw;
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public void WithdrawSavings(double amountToWithdraw)
    {
        if (_balanceSavings > amountToWithdraw)
        {
            _balanceSavings -= amountToWithdraw;
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public double GetBalance()
    {
        return _balance;
    }

    public double GetBalanceSavings()
    {
        return _balanceSavings;
    }

    public double TotalBalance()
    {
        return _balance + _balanceSavings;
    }

    public void TransferFromChecking(double amountToTransfer)
    {
        if (_balance >= amountToTransfer)
        {
            _balance -= amountToTransfer;
            _balanceSavings += amountToTransfer;
        }

        else
        {
            Console.WriteLine("Invalid account number or transfer amount.");
        }
    }

    public void TransferFromSavings(double amountToTransfer)
    {
        if (_balanceSavings >= amountToTransfer)
        {
            _balanceSavings -= amountToTransfer;
            _balance += amountToTransfer;
        }

        else
        {
            Console.WriteLine("Invalid account number or transfer amount.");
        }
    }
}