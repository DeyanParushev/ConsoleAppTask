namespace BettyConsoleApp
{
    public class Bet
    {
        public double BetAmount {get; set; }

        public double Winning {get; set; }

        public bool IsALooseBet => this.Winning == 0;

        public bool IsABigWin => this.Winning / this.BetAmount > 2;
    }
}
