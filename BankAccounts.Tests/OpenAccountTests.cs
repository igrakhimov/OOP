using BankAccounts.Models;
using FluentAssertions;
using NUnit.Framework;

namespace BankAccounts.Tests;

public class OpenAccountTests
{
    [Test]
    public void BankAccountCreation()
    {
        var bankAccount = new BankAccount("Igor Rakhimov", 1000);
        bankAccount.Owner.Should().Be("Igor Rakhimov");
        bankAccount.Balance.Should().Be(1000);
    }

    [Test]
    public void BankAccountCreateNegativeInitialBalance()
    {
        var bankAccount = new BankAccount("Negative Initial Balance", -50);
        bankAccount.Balance.Should().Be(0);
    }
}