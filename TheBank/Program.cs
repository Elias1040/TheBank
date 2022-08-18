using TheBank;

Menu();

static void Menu()
{
    Bank bank = new Bank();

    #region Menu List
    List<string> menu = new List<string>();
    menu.Add("1. Create Account");
    menu.Add("2. Deposit");
    menu.Add("3. Withdraw");
    menu.Add("4. Show balance");
    menu.Add("5. Show bank");
    #endregion

    do
    {
        Console.Clear();
        Console.WriteLine($"Velkommen til {bank.BankName}");
        foreach (string option in menu)
        {
            Console.WriteLine(option);
        }
        Console.CursorVisible = false;
        switch (Console.ReadKey(true).Key)
        {
            #region Create account
            case ConsoleKey.D1 or ConsoleKey.NumPad1:
                Console.CursorVisible = true;
                Console.Clear();
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.Clear();
                    Console.WriteLine("Navn kan ikke være tomt!");
                    Console.WriteLine("Name: ");
                    name = Console.ReadLine();
                }
                Console.Clear();
                bank.CreateAccount(name);
                Console.CursorVisible = false;
                Console.WriteLine($"Konto oprettet med navn {bank.account.Name} og nummer {bank.account.AccountNumber}");
                Console.ReadKey(true);
                break;
            #endregion

            #region Deposit
            case ConsoleKey.D2 or ConsoleKey.NumPad2:
                Console.CursorVisible = true;
                Console.Clear();
                Console.WriteLine("Indtast kontonummer");
                int number = ValidateInt();
                Console.Clear();
                Console.WriteLine("Indtast beløb: ");
                decimal amount = ValidateDecimal();
                Console.CursorVisible = false;
                bool checkNull = bank.Deposit(number, amount).HasValue;
                Console.WriteLine(checkNull ? "Saldo efter indsæt: {0:c}": "Konto findes ikke", bank.Balance(number)); 
                Console.ReadKey(true);
                break;
            #endregion

            #region Withdraw
            case ConsoleKey.D3 or ConsoleKey.NumPad3:
                Console.CursorVisible = true;
                Console.Clear();
                Console.WriteLine("Indtast kontonummer");
                number = ValidateInt();
                Console.Clear();
                Console.WriteLine("Indtast beløb: ");
                amount = ValidateDecimal();
                Console.CursorVisible = false;
                checkNull = bank.Withdraw(number, amount) != null;
                Console.WriteLine( checkNull ? "Saldo efter hæv: {0:c}" : "Konto findes ikke", bank.Balance(number));
                Console.ReadKey(true);
                break;
            #endregion

            #region Balance
            case ConsoleKey.D4 or ConsoleKey.NumPad4:
                Console.Clear();
                Console.WriteLine("Indtast kontonummer:");
                number = ValidateInt();
                checkNull = bank.Balance(number).HasValue;
                Console.WriteLine(checkNull ? "Saldo er: {0:c}" : "Konto findes ikke", bank.Balance(number));
                Console.ReadKey(true);
                break;
            #endregion

            #region Bank Name
            case ConsoleKey.D5 or ConsoleKey.NumPad5:
                Console.Clear();
                Console.WriteLine($"Bank: {bank.BankName}");
                Console.WriteLine("Bank saldo: {0:c}", bank.BankBalance());
                Console.ReadKey(true);
                break;
            #endregion

            #region Exit
            case ConsoleKey.Escape:
                Environment.Exit(0);
                break;
            #endregion

            #region Default
            default:
                Console.Clear();
                break;
                #endregion
        }
    } while (true);
}

static decimal ValidateDecimal()
{
    decimal amount;
    while (!decimal.TryParse(Console.ReadLine(), out amount))
    {
        Console.Clear();
        Console.WriteLine("Ugyldigt input!");
        Console.WriteLine("Indtast beløb: ");
    }
    Console.Clear();
    return amount;
}

static int ValidateInt()
{
    int amount;
    while (!int.TryParse(Console.ReadLine(), out amount))
    {
        Console.Clear();
        Console.WriteLine("Ugyldigt input!");
        Console.WriteLine("Indtast beløb: ");
    }
    Console.Clear();
    return amount;
}