using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank.Models
{
    public record CheckingAccount : Account
    {
        public CheckingAccount(string name, int accountNumber) : base()
        {
            Name = name;
            AccountNumber = accountNumber;
            AccountType = "Lønkonto";
        }

        public override decimal ChargeInterest()
        {
            return Balance *= 1.005m;
        }

    }
}
