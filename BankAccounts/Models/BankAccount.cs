using System.Text;

namespace BankAccounts.Models;

public class BankAccount
{
    private static int _accountNumberSeed = 1234567890;
    private readonly List<Transaction> _allTransactions = new();

    private readonly decimal _minimumBalance;

    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
    {
    }

    protected BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        Number = _accountNumberSeed.ToString();
        _accountNumberSeed++;

        Owner = name;
        _minimumBalance = minimumBalance;
        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    public string Number { get; }
    public string Owner { get; set; }

    public decimal Balance
    {
        get
        {
            return _allTransactions.Sum(item => item.Amount);
        }
    }

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
        Transaction withdrawal = new(-amount, date, note);
        _allTransactions.Add(withdrawal);
        if (overdraftTransaction != null)
            _allTransactions.Add(overdraftTransaction);
    }

    public string GetAccountHistory()
    {
        var report = new StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }

    public virtual void PerformMonthEndTransactions()
    {
    }
    
    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
        if (isOverdrawn)
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        return default;
    }
}