using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public IEnumerable<Movement> MakeStatement(Customer customer, Account account)
        {
            Contract.Requires(customer.Accounts.Contains(account));

            return account.Debits.Concat(account.Credits);
        }

        [ContractInvariantMethod]
        private void Invariant()
        {

            Contract.Invariant(0 == DoubleBookKeeping());
        }


        private double DoubleBookKeeping()
        {
            double sum = 0;

            foreach (var account in Accounts)
            {
                sum -= account.Debits.Sum(x => x.Amount);
                sum += account.Credits.Sum(x => x.Amount);
            }


            return sum;
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