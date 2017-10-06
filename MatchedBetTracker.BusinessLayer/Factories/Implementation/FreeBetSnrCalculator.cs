using MatchedBetTracker.BusinessLayer.Factories.Interfaces;
using MatchedBetTracker.BusinessLayer.ServiceModels;

namespace MatchedBetTracker.BusinessLayer.Factories.Implementation
{
    public class FreeBetSnrCalculator : IBetCalculator
    {
        public BetCalculationModel Calculate(double backStake, double backOdds, double layOdds, double layCommission)
        {
            var optimalLayStake = (backOdds - 1) / (layOdds - layCommission) * backStake;

            var bookmakerWinProfit = (backOdds - 1) * backStake - (layOdds - 1) * optimalLayStake;

            var exchangeWinProfit = optimalLayStake * (1 - layCommission);

            var liability = optimalLayStake * (layOdds - 1);

            return new BetCalculationModel
            {
                LayStake = optimalLayStake,
                BookMakerWinProfit = bookmakerWinProfit,
                ExchangeWinProfit = exchangeWinProfit,
                Liability = liability
            };
        }
    }
}