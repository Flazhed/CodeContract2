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

            Customer Lone = new Customer()
            {
                Id = 3,
                Name = "Lone",
                Accounts = new List<Account>()
            };

            Customer Ib = new Customer()
            {
                Id = 4,
                Name = "Ib",
                Accounts = new List<Account>()
            };

            Account acc1 = new Account(123, 1000);
            Account acc2 = new Account(593, 1000);
            Account acc3 = new Account(312, 1000);
            Account acc4 = new Account(515, 1000);
            Account acc5 = new Account(666, 1000);

            kurt.AddAcount(acc1);
            sonja.AddAcount(acc2);
            Lone.AddAcount(acc3);
            Ib.AddAcount(acc4);

            Bank bank = new Bank("Best Bank");
            bank.AddCustomer(kurt);
            bank.AddCustomer(sonja);

            bank.AddAccount(acc1);
            bank.AddAccount(acc2);
            bank.AddAccount(acc3);
            bank.AddAccount(acc4);
            bank.AddAccount(acc5);


            bank.Move(200.00, acc1, acc2);
            bank.Move(100.00, acc2, acc1);
            bank.Move(150.00, acc4, acc2);
            bank.Move(100.00, acc5, acc2);
            bank.Move(350.50, acc2, acc3);
            bank.Move(141.00, acc2, acc1);
            bank.Move(115.00, acc3, acc2);
            bank.Move(515.00, acc4, acc2);
            bank.Move(70.58, acc1, acc2);


            var movemnt = bank.MakeStatement(sonja, acc2);
            foreach (var movement in movemnt)
            {
                Console.WriteLine(movement);
            }

            Console.ReadKey();

        }
    }
}
