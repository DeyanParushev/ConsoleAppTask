using BettyConsoleApp.Interfaces;

namespace BettyConsoleApp
{
    public class Game : IGame
    {
        private static readonly int minWinRange = 10;
        private static readonly int midWinRange = 20;
        private static readonly int maxWinRange = 100;

        private static readonly double betFailRateThreshold = 0.5;
        private static readonly double bigWinningRateThreshold = 0.1;

        private static double minBetAmount = 1;
        private static double maxBetAmount = 10;
        private static readonly ICollection<Bet> placedBets = new List<Bet>();

        public double PlaceABet(double betAmount)
        {
            if (betAmount < minBetAmount || betAmount > maxBetAmount)
            {
                throw new InvalidOperationException(Constants.InvalidBetAmountMessage);
            }
            
            var bet = new Bet();
            bet.BetAmount = betAmount;
            placedBets.Add(bet);
            
            var multiplicationCoefficient = (double)0;
            var batFailRate = GetFailRate();

            if (batFailRate < betFailRateThreshold)
            {
                bet.Winning = betAmount * multiplicationCoefficient;
                placedBets.Add(bet);
                return bet.Winning;
            }

            var bigWinningsRate = GetBigWinningsBetRate();

            if (bigWinningsRate > bigWinningRateThreshold)
            {
                multiplicationCoefficient = GetRandomMultiplicationFactor(minWinRange, midWinRange);
            } 
            else
            {
                multiplicationCoefficient = GetRandomMultiplicationFactor(midWinRange, maxWinRange);
            }

            bet.Winning = betAmount * multiplicationCoefficient;
            return bet.Winning;
        }

        private double GetFailRate()
        {
            var successBets = (double)placedBets.Where(b => b.IsALooseBet).Count();
            var betSuccessRate =  successBets / (double)placedBets.Count;
            return betSuccessRate;
        }

        private double GetBigWinningsBetRate()
        {
            var bigWinningsBetRate = (double)placedBets.Where(b => b.IsABigWin).Count() / (double)placedBets.Count;
            return bigWinningsBetRate;
        }

        private double GetRandomMultiplicationFactor(int minRange, int maxRange)
        {
            var random = new Random();
            var multiplicationFactor = (double)random.Next(minRange, maxRange) / 10;
            return multiplicationFactor;
        }
    }
}
