using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBank;

namespace TheBank
{
    public class Bank
    {
        public string BankName { get; }
        public Account account { get; set; }

        public Bank()
        {
            BankName = "EUC Bank";
        }

        public Account CreateAccount(string name)
        {
            return account = new Account(name);
        }

        public decimal Deposit(decimal amount)
        {
            return account.Balance += amount;
        }

        public decimal Withdraw(decimal amount)
        {
            return account.Balance -= amount;
        }

        public decimal Balance()
        {
            return account.Balance;
        }
    }
}
