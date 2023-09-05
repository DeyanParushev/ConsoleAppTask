namespace BettyConsoleApp
{
    public static class Constants
    {
        public static string DepositCommand = "deposit";

        public static string WithdrawCommand = "withdraw";

        public static string ExitGameCommand = "exit";

        public static string BetCommand = "bet";

        public static string BetFailMessage = "No luck this time!";

        public static string ExitGameMessage = "Thank you for playing! Hope to see you again soon.";

        public static string PromptUserMessage = $"{Environment.NewLine}Please, submit action:";

        public static string InsufficientFundsMessage = "Insufficient finds.";

        public static string InvalidBetAmountMessage = "The bet amount must be between $1 and $10.";

        public static string InvalidCommand = "Invalid command. Valid commands are: exit, deposit, bet and withdraw.";

        public static string DepositMessage(double amount) => $"Your deposit of ${amount} was successful.";

        public static string BetSuccessMessage(double amount) => $"Congrats - you won ${amount}!";

        public static string WithdrawalSuccessMessage(double amount) => $"Your withdrawal of ${amount} was successful.";

        public static string PersonalBalance(double amount) => $"Your current balance is: ${amount}";
    }
}
