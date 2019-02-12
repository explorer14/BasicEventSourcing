using ConsoleApp14;
using FluentAssertions;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var account = new BankAccount();
            account.Credit(100);
            account.Debit(100);
            account.GetCurrentBalance().Should().Be(0);
        }

        [Fact]
        public void Test2()
        {
            var account = new BankAccount();
            account.Credit(100);
            account.Credit(100);
            account.Debit(50);
            account.GetCurrentBalance().Should().Be(150);
        }
    }
}
