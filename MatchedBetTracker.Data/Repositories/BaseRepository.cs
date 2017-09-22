namespace MatchedBetTracker.Data.Repositories
{
    public class BaseRepository
    {
        protected static readonly AsyncLock Locker = new AsyncLock();
    }
}
