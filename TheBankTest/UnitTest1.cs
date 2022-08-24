using System.Xml.Linq;
using TheBank;
using TheBank.Models;
using TheBank.Repository;

namespace TheBankTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("a", ConsoleKey.D1)]
        [InlineData("a", ConsoleKey.D2)]
        [InlineData("a", ConsoleKey.D3)]
        public void CreateAccountTest(string name, ConsoleKey key)
        {
            BankRepo bankRepo = new BankRepo();
            AccountListItem acc = new(bankRepo.CreateAccount(name, key));
            Assert.Contains(acc, bankRepo.GetAccountList());
        }

        [Fact]
        public void DepositTest()
        {
            BankRepo bankRepo = new();
            Account account = bankRepo.CreateAccount("a", ConsoleKey.D1);
            Assert.Equal(100, bankRepo.Deposit(0, 100));
        }

        [Fact]
        public void WithdrawTest()
        {
            BankRepo bankRepo = new();
            Account account = bankRepo.CreateAccount("a", ConsoleKey.D1);
            Assert.Equal(-100, bankRepo.Withdraw(0, 100));
        }

        [Fact]
        public void BalanceTest()
        {
            BankRepo bankRepo = new();
            Account account = bankRepo.CreateAccount("a", ConsoleKey.D1);
            Assert.Equal(bankRepo.Deposit(0, 100), bankRepo.Balance(0));
        }

        [Fact]
        public void BankBalanceTest()
        {
            BankRepo bankRepo = new();
            Account account = bankRepo.CreateAccount("a", ConsoleKey.D1);
            Account account1 = bankRepo.CreateAccount("a", ConsoleKey.D1);
            bankRepo.Deposit(0, 100);
            bankRepo.Deposit(1, -100);
            Assert.Equal(0, bankRepo.BankBalance());
        }

        [Theory]
        [InlineData("a", ConsoleKey.D1, 100)]
        [InlineData("a", ConsoleKey.D2, 100)]
        [InlineData("a", ConsoleKey.D3, 100)]
        public void ChargeInterest(string name, ConsoleKey key, int amount)
        {
            BankRepo bankRepo = new();
            Account account = bankRepo.CreateAccount(name, key);
            //Account account1 = bankRepo.CreateAccount("a", ConsoleKey.D2);
            //Account account2 = bankRepo.CreateAccount("a", ConsoleKey.D3);

            bankRepo.Deposit(account.AccountNumber, amount);
            //bankRepo.Deposit(1, 100);
            //bankRepo.Deposit(2, 100);

            bankRepo.ChargeInterest();
            switch (account.AccountType)
            {
                case "Lønkonto":
                Assert.Equal(, bankRepo.Balance(0));
                    break;
                default:
                    break;
            }
            Assert.Equal(account.ChargeInterest(amount), bankRepo.Balance(0));
            //Assert.Equal(100*1.01m, bankRepo.Balance(1));
            //Assert.Equal(100*1.01m, bankRepo.Balance(2));
        }

        [Fact]
        public void Check_if_same_account()
        {
            BankRepo bankRepo = new();
            AccountListItem createdAcc = new(bankRepo.CreateAccount("", ConsoleKey.D1));
            AccountListItem acc = bankRepo.GetAccountList().Find(x => x.Account.AccountNumber == 0);
            Assert.NotSame(createdAcc, acc);
        }

    }
}