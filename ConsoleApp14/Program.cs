using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount();
            account.Credit(100);
            account.Credit(100);
            account.Credit(100);
            account.Credit(100);
            account.Credit(100);
            account.Credit(100);

            account.Debit(100);
            account.Debit(100);
            account.Debit(100);
            account.Debit(100);
            account.Debit(100);
            Console.WriteLine(account.GetCurrentBalance());
        }
    }

    public class BankAccount
    {
        private readonly List<Transaction> transactions 
            = new List<Transaction>();

        public BankAccount()
        {
            Id = Guid.NewGuid();
            IsActive = true;
        }

        public Guid Id { get; }

        public decimal GetCurrentBalance() => 
            this.transactions.Sum(x => x.Amount);

        public bool IsActive { get; internal set; }

        public void Credit(decimal creditAmount)
        {
            this.transactions.Add(
                new Credit(creditAmount));
        }

        public void Debit(decimal debitAmount)
        {
            this.transactions.Add(
                new Debit(debitAmount));
        }
    }

    public abstract class Transaction
    {
        protected Transaction()
        {
            TransactionDate = DateTime.UtcNow;
        }

        public abstract decimal Amount { get; }

        public DateTime TransactionDate { get; }
    }

    public class Credit : Transaction
    {
        public Credit(decimal amount) : base()
        {
            Amount = amount;
        }

        public override decimal Amount { get ; }
    }

    public class Debit : Transaction
    {
        public Debit(decimal amount) : base()
        {
            Amount = -1 * amount;
        }

        public override decimal Amount { get ; }
    }
}
