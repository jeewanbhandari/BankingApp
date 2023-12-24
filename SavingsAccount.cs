namespace BankingApp
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, string accountHolder, double initialBalance)
            : base(accountNumber, accountHolder, initialBalance)
        {
        }

        //Implementation of abstract method to display account information
        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Savings Account Number: {AccountNumber}");
            Console.WriteLine($"Savings Account Holder: {AccountHolder}");
            Console.WriteLine($"Savings Account Balance: NPR {Balance}");
            Console.WriteLine("\nTransaction History:");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine($"{transaction.Date} - {transaction.Description}: NPR {transaction.Amount}");
            }
        }
    }
}
