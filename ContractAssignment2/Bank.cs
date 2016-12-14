using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAssignment2
{
    public class Bank
    {
        private string Name { get; set; }
        private List<Customer> Customers { get;}
        private List<Account> Accounts { get;}

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
            new Movement(amount, target, source);
        }

        public void MakeStatement(Customer customer, Account account)
        {
            
        }

        //INVARIANT = Altid nul
    }
}
