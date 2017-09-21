using System.Threading.Tasks;
using MatchedBetTracker.Model.Entities;
using MatchedBetTracker.Repository.Repositories.Interfaces;
using SQLite;

namespace MatchedBetTracker.Repository.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLiteAsyncConnection _conn;
        public string StatusMessage { get; set; }

        public UserRepository(string dbPath)
        {
            _conn = new SQLiteAsyncConnection(dbPath);
            _conn.CreateTableAsync<User>().Wait();
        }

        public async Task CreateUser(User user)
        {
            var result = await _conn.InsertOrReplaceAsync(user).ConfigureAwait(continueOnCapturedContext: false);

            StatusMessage = $"{result} record(s) added [User Name: {user.UserName}])";
        }

        public async Task<User> GetUser()
        {
            var result = await _conn.Table<User>().FirstOrDefaultAsync();

            return result;
        }
    }
}
