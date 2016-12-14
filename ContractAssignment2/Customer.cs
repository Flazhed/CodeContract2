﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractAssignment2
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }

        public void AddAcount(Account account)
        {
            this.Accounts.Add(account);
        }

    }
}
