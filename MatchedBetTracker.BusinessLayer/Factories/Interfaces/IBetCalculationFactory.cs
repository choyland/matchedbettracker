using MatchedBetTracker.BusinessLayer.Factories.Implementation;
using MatchedBetTracker.Model.Enum;

namespace MatchedBetTracker.BusinessLayer.Factories.Interfaces
{
    public interface IBetCalculationFactory
    {
        IBetCalculator GetCalculator(BetType betType);
    }
}
