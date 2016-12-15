using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAssignment2
{
    public class Movement
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public Account Target { get; set; }
        public Account Source { get; set; }

        public Movement(double amount, Account target, Account source)
        {
            this.Date = DateTime.Today;
            this.Amount = amount;
            this.Target = target;
            this.Source = source;

            target.AddCredit(this);
            source.AddDebit(this);
        }

        public override string ToString()
        {
            return $"Movement: {Amount}kr. from {Target} to {Source}";
        }

    }
}
