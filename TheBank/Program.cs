using TheBank;

Bank bank = new Bank();
Console.WriteLine($"Velkommen til {bank.BankName}");
bank.CreateAccount(Console.ReadLine());
Console.WriteLine($"Konto oprettet med navn {bank.account.Name}");
decimal amount;
decimal.TryParse(Console.ReadLine(), out amount);
bank.Deposit(amount);
Console.WriteLine("Saldo efter indsæt: {0:c}", bank.Balance());
decimal.TryParse(Console.ReadLine(), out amount);
bank.Withdraw(amount);
Console.WriteLine("Saldo efter hæv: {0:c}", bank.Balance());
Console.WriteLine("Saldo: {0:c}", bank.Balance());
