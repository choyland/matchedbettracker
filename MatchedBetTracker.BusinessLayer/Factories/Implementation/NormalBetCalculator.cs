using MatchedBetTracker.BusinessLayer.Factories.Interfaces;
using MatchedBetTracker.BusinessLayer.ServiceModels;

namespace MatchedBetTracker.BusinessLayer.Factories.Implementation
{
    public class NormalBetCalculator : IBetCalculator
    {
        public BetCalculationModel Calculate(double backStake, double backOdds, double layOdds, double layCommission)
        {
            var optimalLayStake = backOdds / (layOdds - layCommission) * backStake;

            var bookmakerWinProfit = (backOdds - 1) * backStake - (layOdds - 1) * optimalLayStake;

            var exchangeWinProfit = -backStake + optimalLayStake * (1 - layCommission);

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
