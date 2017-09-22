using MatchedBetTracker.Data.Interfaces;
using SQLite.Net.Async;
using Xamarin.Forms;

namespace MatchedBetTracker.Data
{
    public class SQLiteClient : ISQLiteImplementation
    {
        private readonly ISQLite _sqLite;

        public SQLiteClient()
        {
            _sqLite = DependencyService.Get<ISQLite>();
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return _sqLite.GetAsyncConnection();
        }
    }
}
