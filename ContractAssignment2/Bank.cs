using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAssignment2
{
    public class Bank
    {
        private string Name { get; set; }
        private List<Customer> Customers { get; }
        private List<Account> Accounts { get; }

        public Bank(string name)
        {
            this.Name = name;
            this.Customers = new List<Customer>();
            this.Accounts = new List<Account>();
        }

        public void AddCustomer(Customer customer)
        {
            this.Customers.Add(customer);
        }

        public void AddAccount(Account account)
        {
            this.Accounts.Add(account);
        }

        public void Move(double amount, Account source, Account target)
        {
            //pre
            Contract.Requires(amount > 0);
            Contract.Requires<TransactionException>(source != target, "Can't debit and credit from same account"); 
            //post
            Contract.EnsuresOnThrow<TransactionException>(Contract.OldValue(source.Debits.Count) == source.Debits.Count);
            Contract.EnsuresOnThrow<TransactionException>(Contract.OldValue(source.Credits.Count) == source.Credits.Count);

            new Movement(amount, target, source);
        }

        public void MakeStatement(Customer customer, Account account)
        {
        }

        [ContractInvariantMethod]
        private void Invariant()
        {
            //Hansen do magic
            Contract.Invariant(1 == 1);
        }

        public class TransactionException : Exception
        {
            public TransactionException()
            {
            }

            public TransactionException(string msg) : base(msg)
            {
            }
        }
    }
}