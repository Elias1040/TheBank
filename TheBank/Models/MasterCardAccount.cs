using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank.Models
{
    public record MasterCardAccount : Account
    {
        public MasterCardAccount(string name, int accountNumber) : base()
        {
            Name = name;
            AccountNumber = accountNumber;
            AccountType = "MasterCard konto";
        }
        public override void ChargeInterest()
        {
            if (Balance > 0)
            {
                Balance *= 1.01m;
            }
            else
            {
                Balance *= 1.2m;
            }
        }
    }
}
