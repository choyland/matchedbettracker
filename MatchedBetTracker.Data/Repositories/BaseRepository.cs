using System.Collections.Generic;
using System.Threading.Tasks;
using MatchedBetTracker.Data.Interfaces;

namespace MatchedBetTracker.Data.Repositories
{
    public class BaseRepository
    {
        protected static readonly AsyncLock Locker = new AsyncLock();
    }
}
