using BettyConsoleApp.Interfaces;

namespace BettyConsoleApp
{
    public class Player : IPlayer
    {
        private double personalBalance;

        public Player()
        {
             this.personalBalance = 0;
        }

        public void DepositFunds(double amount)
        {
            personalBalance += amount;
        }

        public bool WithdrawFunds(double amount)
        {
            if(amount > personalBalance)
            {
                return false;
            }

            personalBalance -= amount;
            return true;
        }

        public double GetBalance() => this.personalBalance;
    }
}
