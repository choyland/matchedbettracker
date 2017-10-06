using MatchedBetTracker.BusinessLayer.ServiceModels;

namespace MatchedBetTracker.BusinessLayer.Factories.Interfaces
{
    public interface IBetCalculator
    {
        BetCalculationModel Calculate(double backStake, double backOdds, double layOdds, double layCommission);
    }
}