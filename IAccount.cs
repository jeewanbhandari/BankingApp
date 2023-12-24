namespace BankingApp
{
    public interface IAccount
    {
        //represents common operations for all accounts
        string AccountNumber { get; }
        string AccountHolder { get; }
        double Balance { get; }
        IReadOnlyList<Transaction> Transactions { get; }

        void Deposit(double amount, string description);
        void Withdraw(double amount, string description);
        void DisplayAccountInfo();
    }
}
