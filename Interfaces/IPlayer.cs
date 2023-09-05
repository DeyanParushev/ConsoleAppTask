namespace BettyConsoleApp.Interfaces
{
    public interface IPlayer
    {
        void DepositFunds(double amount);

        double GetBalance();

        bool WithdrawFunds(double amount);
    }
}