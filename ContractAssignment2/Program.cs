using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAssignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer kurt = new Customer()
            {
                Id = 1,
                Name = "Kurt Vonnegot",
                Accounts = new List<Account>()
            };
            

            Customer sonja = new Customer()
            {
                Id = 2,
                Name = "Sonja",
                Accounts = new List<Account>()
            };

            Account acc1 = new Account(123);
            Account acc2 = new Account(593);

            kurt.AddAcount(acc1);
            sonja.AddAcount(acc2);

            Bank bank = new Bank("Best Bank");
            bank.AddCustomer(kurt);
            bank.AddCustomer(sonja);

            bank.AddAccount(acc1);
            bank.AddAccount(acc2);

            bank.Move(200.00, acc1, acc2);
            bank.Move(100.00, acc2, acc1);

            Console.ReadKey();

        }
    }
}
