namespace BankingApp
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the XYZ Bank!");

            var accounts = new List<IAccount>();

            while (true)
            {
                Console.WriteLine("\nPlease Choose an option:");
                Console.WriteLine("1. Create Bank Account");
                Console.WriteLine("2. Manage Bank Account");
                Console.WriteLine("3. Exit");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Error: Invalid input. Please enter a number between 1 and 3.");
                }

                switch (choice)
                {
                    case 1:
                        CreateAccount(accounts);
                        break;

                    case 2:
                        ManageAccount(accounts);
                        break;

                    case 3:
                        Console.WriteLine("Thank you for using XYZ Bank. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Error: Invalid choice. Please choose a number between 1 and 3.");
                        break;
                }
            }
        }

        //Create new account
        private static void CreateAccount(List<IAccount> accounts)
        {
            Console.Write("Enter account type (1 for Savings): ");
            int accountType;
            while (!int.TryParse(Console.ReadLine(), out accountType) || accountType != 1)
            {
                Console.WriteLine("Error: Only Savings Account (type 1) is available at the moment.");
                Console.Write("Enter account type: ");
            }

            switch (accountType)
            {
                case 1:
                    CreateSavingsAccount(accounts);
                    break;

                default:
                    Console.WriteLine("Error: Invalid account type.");
                    break;
            }
        }

        //Create a new savings account
        private static void CreateSavingsAccount(List<IAccount> accounts)
        {
            Console.Write("Enter savings account number: ");
            string accountNumber = Console.ReadLine();

            //Check for account number validity and uniqueness
            if (IsValidSavingsAccountNumber(accountNumber) && IsAccountNumberUnique(accounts, accountNumber))
            {
                string accountHolder = GetValidatedAccountHolderName();

                Console.Write("Enter initial balance: ");
                double initialBalance = GetValidatedAmount();

                var newAccount = new SavingsAccount(accountNumber, accountHolder, initialBalance);
                accounts.Add(newAccount);

                Console.WriteLine("\nSavings account created successfully!");
                DisplayAccountInfo(newAccount); //display account info
            }
            else
            {
                Console.WriteLine("Error: To create an account, the account number must have at least 10 digits (letters allowed) and should be unique.");
            }
        }


        //managing existing account
        private static void ManageAccount(List<IAccount> accounts)
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            var account = accounts.Find(acc => acc.AccountNumber == accountNumber);

            if (account != null)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Display Account Information");
                Console.WriteLine("4. Go Back");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Error: Invalid input. Please enter a number between 1 and 4.");
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter deposit amount: ");
                        double depositAmount = GetValidatedAmount();
                        Console.Write("Enter deposit purpose: ");
                        string depositDescription = Console.ReadLine();
                        account.Deposit(depositAmount, depositDescription);
                        break;

                    case 2:
                        Console.Write("Enter withdrawal amount: ");
                        double withdrawalAmount = GetValidatedAmount();
                        Console.Write("Enter withdrawal purpose: ");
                        string withdrawalDescription = Console.ReadLine();
                        account.Withdraw(withdrawalAmount, withdrawalDescription);
                        break;

                    case 3:
                        account.DisplayAccountInfo();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Error: Invalid choice. Please choose a number between 1 and 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error: Account not found. Please make sure the account number is correct.");
            }
        }

        private static void DisplayAccountInfo(IAccount account)
        {
            Console.WriteLine("\nAccount Information:");
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Account Holder: {account.AccountHolder}");
            Console.WriteLine($"Balance: NPR {account.Balance}");
        }

        //validated amount
        private static double GetValidatedAmount()
        {
            double amount;
            while (!double.TryParse(Console.ReadLine(), out amount) || amount < 0)
            {
                Console.WriteLine("Error: Invalid input. Amount must be a non-negative number.");
                Console.Write("Enter amount: NPR ");
            }
            return amount;
        }

        //validated account holder name
        private static string GetValidatedAccountHolderName()
        {
            string accountHolder;
            do
            {
                Console.Write("Enter account holder name: ");
                accountHolder = Console.ReadLine();

                if (IsAlphabeticWithSpaces(accountHolder) && accountHolder.Length >= 4)
                {
                    break;
                }

                Console.WriteLine("Error: Account holder name must be alphabetic and at least four characters long.");
            } while (true);

            return accountHolder;
        }

        private static bool IsAlphabeticWithSpaces(string input)
        {
            return input.All(char.IsLetter) || input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }



        //checking the validity of savings account number
        private static bool IsValidSavingsAccountNumber(string accountNumber)
        {
            return accountNumber.Length >= 10 && accountNumber.Any(char.IsDigit) && !accountNumber.All(char.IsLetter);
        }

        //Check the uniqueness of account number.
        private static bool IsAccountNumberUnique(List<IAccount> accounts, string accountNumber)
        {
            return !accounts.Any(acc => acc.AccountNumber == accountNumber);
        }
    }
}
