using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank.Models
{
    public record CheckingAccount : Account
    {
        public CheckingAccount(string name, int accountNumber)
        {
            Name = name;
            AccountNumber = accountNumber;
            AccountType = "Lønkonto";
        }

        public override void ChargeInterest()
        {
            Balance *= 1.005m;
        }

    }
}
