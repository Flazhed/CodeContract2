using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAssignment2
{
    public class Account
    {
        private int Number { get; set; }
        private double Balance { get; set; }
        public List<Movement> Debits { get; }
        public List<Movement> Credits { get; }

        public Account(int number, double balance)
        {
            this.Number = number;
            this.Balance = balance;
            this.Debits = new List<Movement>();
            this.Credits = new List<Movement>();
        }

        public void AddDebit(Movement debit)
        {
            Contract.Requires<AccountException>(debit.Amount > 0, "Amount should be greater then zero");
            Contract.Ensures(Contract.OldValue(Balance) > Balance);

            this.Debits.Add(debit);
            this.Balance -= debit.Amount;
        }

        public void AddCredit(Movement credit)
        {
            Contract.Requires<AccountException>(credit.Amount > 0, "Amount should be greater then zero");
            Contract.Ensures(Contract.OldValue(Balance) < Balance);

            this.Credits.Add(credit);
            this.Balance += credit.Amount;
        }

        [ContractInvariantMethod]
        private void Invariant()
        {
            Contract.Invariant(this.Balance >= 0);
        }

        public class AccountException : Exception
        {
        }

        public override string ToString()
        {
            return "account " + Number;
        }
    }
}