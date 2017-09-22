using SQLite.Net.Async;

namespace MatchedBetTracker.Data.Interfaces
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
