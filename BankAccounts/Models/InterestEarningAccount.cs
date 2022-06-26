namespace BankAccounts.Models;

public class InterestEarningAccount : BankAccount
{
    public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {
    }

    public override void PerformMonthEndTransactions()
    {
        if (Balance <= 500m) return;
        var interest = Balance * 0.05m;
        MakeDeposit(interest, DateTime.Now, "apply monthly interest");
    }
}