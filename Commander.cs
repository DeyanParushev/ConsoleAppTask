using BettyConsoleApp.Interfaces;

namespace BettyConsoleApp
{
    public class Commander : ICommander
    {
        public bool ExecuteCommand(string command, IPlayer player, IGame game)
        {
            if (command.ToLower().Contains(Constants.BetCommand))
            {
                var amount = Double.Parse(ExtractAmountFromCommand(command));
                ExecuteBet(player, amount, game);
                return true;
            }

            if (command.ToLower().Contains(Constants.WithdrawCommand))
            {
                var amount = Double.Parse(ExtractAmountFromCommand(command));
                ExecuteWithdraw(player, amount);
                return true;
            }

            if (command.ToLower().Contains(Constants.DepositCommand))
            {
                var amount = Double.Parse(ExtractAmountFromCommand(command));
                ExecuteDeposit(player, amount);
                return true;
            }

            if (command.ToLower().Contains(Constants.ExitGameCommand))
            {
                ExecuteExit();
                return false;
            }

            ConsoleInteractor.WriteMessage(Constants.InvalidCommand);
            return true;
        }

        private void ExecuteBet(IPlayer player, double amount, IGame game)
        {
            try
            {
                if (player.GetBalance() < amount)
                {
                    ConsoleInteractor.WriteMessage(Constants.InsufficientFundsMessage);
                    ConsoleInteractor.WriteMessage(Constants.PersonalBalance(player.GetBalance()));
                    return;
                }

                var betWinnings = game.PlaceABet(amount);
                player.WithdrawFunds(amount);

                if (betWinnings > 0)
                {
                    player.DepositFunds(betWinnings);
                    ConsoleInteractor.WriteMessage(Constants.BetSuccessMessage(betWinnings));
                    ConsoleInteractor.WriteMessage(Constants.PersonalBalance(player.GetBalance()));
                    return;
                }

                ConsoleInteractor.WriteMessage(Constants.BetFailMessage);
                ConsoleInteractor.WriteMessage(Constants.PersonalBalance(player.GetBalance()));
            }
            catch (Exception e)
            {
                ConsoleInteractor.WriteMessage(e.Message);
                return;
            }
        }

        private void ExecuteWithdraw(IPlayer player, double amount)
        {
            if (player.WithdrawFunds(amount))
            {
                ConsoleInteractor.WriteMessage(Constants.WithdrawalSuccessMessage(amount));
                ConsoleInteractor.WriteMessage(Constants.PersonalBalance(player.GetBalance()));
                return;
            }

            ConsoleInteractor.WriteMessage(Constants.InsufficientFundsMessage);
            ConsoleInteractor.WriteMessage(Constants.PersonalBalance(player.GetBalance()));
        }

        private void ExecuteDeposit(IPlayer player, double amount)
        {
            player.DepositFunds(amount);
            ConsoleInteractor.WriteMessage(Constants.DepositMessage(amount));
            ConsoleInteractor.WriteMessage(Constants.PersonalBalance(player.GetBalance()));
        }

        private void ExecuteExit()
        {
            ConsoleInteractor.WriteMessage(Constants.ExitGameMessage);
        }

        private string ExtractAmountFromCommand(string command) => command.Split(' ')[1];
    }
}
