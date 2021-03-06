using BankAccounts.Models;

var account = new BankAccount("Igor Rakhimov", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.GetAccountHistory());

var giftCard = new GiftCardAccount("gift card", 100, 350);
Console.WriteLine(
    $"Account {giftCard.Number} was created for {giftCard.Owner} with {giftCard.Balance} initial balance.");
giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();
// can make additional deposits:
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestEarningAccount("savings account", 10000);
Console.WriteLine($"Account {savings.Number} was created for {savings.Owner} with {savings.Balance} initial balance.");
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountHistory());

var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
Console.WriteLine(
    $"Account {lineOfCredit.Number} was created for {lineOfCredit.Owner} with {lineOfCredit.Balance} initial balance.");
// How much is too much to borrow?
lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
lineOfCredit.PerformMonthEndTransactions();
Console.WriteLine(lineOfCredit.GetAccountHistory());