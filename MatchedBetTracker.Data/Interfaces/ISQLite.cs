using SQLite;

namespace MatchedBetTracker.Data.Interfaces
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
