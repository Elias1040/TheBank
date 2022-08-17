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
                Console.WriteLine($"Konto oprettet med navn {bank.account.Name}");
                Console.ReadKey(true);
                break;
            #endregion

            #region Deposit
            case ConsoleKey.D2 or ConsoleKey.NumPad2:
                Console.CursorVisible = true;
                Console.Clear();
                Console.WriteLine("Indtast beløb: ");
                decimal amount;
                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Clear();
                    Console.WriteLine("Ugyldigt input!");
                    Console.WriteLine("Indtast beløb: ");
                }
                Console.Clear();
                Console.CursorVisible = false;
                bank.Deposit(amount);
                Console.WriteLine("Saldo efter indsæt: {0:c}", bank.Balance());
                Console.ReadKey(true);
                break;
            #endregion

            #region Withdraw
            case ConsoleKey.D3 or ConsoleKey.NumPad3:
                Console.CursorVisible = true;
                Console.Clear();
                Console.WriteLine("Indtast beløb: ");
                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Clear();
                    Console.WriteLine("Ugyldigt input!");
                    Console.WriteLine("Indtast beløb: ");
                }
                Console.Clear();
                Console.CursorVisible = false;
                bank.Withdraw(amount);
                Console.WriteLine("Saldo efter hæv: {0:c}", bank.Balance());
                Console.ReadKey(true);
                break;
            #endregion

            #region Balance
            case ConsoleKey.D4 or ConsoleKey.NumPad4:
                Console.Clear();
                Console.WriteLine("Saldo: {0:c}", bank.Balance());
                Console.ReadKey(true);
                break;
            #endregion

            #region Bank Name
            case ConsoleKey.D5 or ConsoleKey.NumPad5:
                Console.Clear();
                Console.WriteLine($"Bank: {bank.BankName}");
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