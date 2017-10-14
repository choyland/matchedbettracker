using System;

namespace MatchedBetTracker.BusinessLayer.Providers.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime GetDateTimeNowUtc();
    }
}
