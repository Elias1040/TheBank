using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank
{
    abstract public class Account
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }

        public abstract void ChargeInterest();
    }
    
    public class CheckingAccount : Account
    {
        public CheckingAccount(string name, int accountNumber)
        {
            Name = name;
            AccountNumber = accountNumber;
        }

        public override void ChargeInterest()
        {
            Balance *= 1.005m;
        }

    }

    public class SavingsAccount : Account
    {
        public SavingsAccount(string name, int accountNumber)
        {
            Name = name;
            AccountNumber = accountNumber;
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

    public class MasterCardAccount : Account
    {
        public MasterCardAccount(string name, int accountNumber)
        {
            Name = name;
            AccountNumber = accountNumber;
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
