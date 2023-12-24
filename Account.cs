namespace BankingApp
{
    public abstract class Account : IAccount
    {
        private string accountNumber;
        private string accountHolder;
        protected double balance;
        protected readonly List<Transaction> transactions;

        public string AccountNumber
        {
            get => accountNumber;
            set
            {
                if (IsValidAccountNumber(value))
                {
                    accountNumber = value;
                }
                else
                {
                    throw new ArgumentException("Error: To create an account, the account number must have at least 10 digits (letters allowed).");
                }
            }
        }

        public string AccountHolder => accountHolder;

        public double Balance => balance;

        public IReadOnlyList<Transaction> Transactions => transactions.AsReadOnly();

        public Account(string accountNumber, string accountHolder, double initialBalance)
        {
            AccountNumber = accountNumber;
            this.accountHolder = accountHolder;
            balance = initialBalance;
            transactions = new List<Transaction>();
        }

        //deposit funds in bank account
        public virtual void Deposit(double amount, string description)
        {
            ValidatePositiveAmount(amount);
            balance += amount;
            RecordTransaction(amount, description);
            Console.WriteLine($"Deposited NPR {amount}. New balance: NPR {balance}");
        }

        //withdraw funds from the account
        public virtual void Withdraw(double amount, string description)
        {
            ValidatePositiveAmount(amount);
            try
            {
                if (amount > balance)
                {
                    throw new InvalidOperationException("Insufficient funds for withdrawal.");
                }

                balance -= amount;
                RecordTransaction(-amount, description);
                Console.WriteLine($"Withdrawn NPR {amount}. New balance: NPR {balance}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //Abstract method to display account information
        public abstract void DisplayAccountInfo();

        //record a transaction
        protected void RecordTransaction(double amount, string description)
        {
            var transaction = new Transaction
            {
                Amount = amount,
                Description = description,
                Date = DateTime.Now
            };

            transactions.Add(transaction);
        }

        //validate a positive amount
        private static void ValidatePositiveAmount(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Error: Amount must be greater than 0.");
            }
        }

        //validate a valid account number
        private static bool IsValidAccountNumber(string accountNumber)
        {
            return accountNumber.Length >= 10 && accountNumber.Any(char.IsDigit) && !accountNumber.All(char.IsLetter);
        }
    }
}
