using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank.Models
{
    public record SavingsAccount : Account
    {
        public SavingsAccount(string name, int accountNumber)
        {
            Name = name;
            AccountNumber = accountNumber;
            AccountType = "Opsparingskonto";
        }

        public override void ChargeInterest()
        {
            if (Balance > 100000)
            {
                Balance *= 1.03m;
            }
            else if (Balance >= 50000)
            {
                Balance *= 1.02m;
            }
            else if (Balance < 50000)
            {
                Balance *= 1.01m;
            }
        }
    }
}
