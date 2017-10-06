using System;
using MatchedBetTracker.BusinessLayer.Factories.Interfaces;
using MatchedBetTracker.Model.Enum;

namespace MatchedBetTracker.BusinessLayer.Factories.Implementation
{
    public class BetCalculationFactory : IBetCalculationFactory
    {
        public IBetCalculator GetCalculator(BetType betType)
        {
            {
                switch (betType)
                {
                    case BetType.Qualifier:
                        return new NormalBetCalculator();
                    case BetType.FreeBetSnr:
                        return new FreeBetSnrCalculator();
                    case BetType.FreeBetSr:
                        return new FreeBetSrCalculator();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(betType), betType, null);
                }
            }
        }
    }
}
