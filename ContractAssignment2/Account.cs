using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAssignment2
{
    public class Account
    {
        private int Number { get; set; }
        private double Balance { get; set; }
        private List<Movement> Debits { get; }
        private List<Movement> Credits { get; }

        public Account(int number)
        {
            this.Number = number;
            this.Balance = 0;
            this.Debits = new List<Movement>();
            this.Credits = new List<Movement>();
        }

        public void AddDebit(Movement debit)
        {
            this.Debits.Add(debit);
            this.Balance -= debit.Amount;
        }

        public void AddCredit(Movement credit)
        {
            this.Credits.Add(credit);
            this.Balance += credit.Amount;
        }

    }
}
