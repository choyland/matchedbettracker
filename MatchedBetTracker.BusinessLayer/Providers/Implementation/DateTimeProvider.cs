using System;
using MatchedBetTracker.BusinessLayer.Providers.Interfaces;

namespace MatchedBetTracker.BusinessLayer.Providers.Implementation
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDateTimeNowUtc()
        {
            return DateTime.UtcNow;
        }
    }
}
