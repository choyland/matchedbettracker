using System.Threading.Tasks;
using MatchedBetTracker.Data.Interfaces;
using MatchedBetTracker.Model.Entities;
using MatchedBetTracker.Repository.Repositories.Interfaces;
using SQLite;

namespace MatchedBetTracker.Data.Repositories.Implementation
{
    public class BookMakerRepository : IBookMakerRepository
    {
        private readonly ISQLiteImplementation _sqLiteImplementation;
        public string StatusMessage { get; set; }

        public BookMakerRepository(ISQLiteImplementation sqLiteImplementation)
        {
            _sqLiteImplementation = sqLiteImplementation;
        }

        //public async Task CreateUser(User user)
        //{
        //    using (await AsyncLock.Locker)
        //    var result = await _conn.InsertOrReplaceAsync(user).ConfigureAwait(continueOnCapturedContext: false);

        //    StatusMessage = $"{result} record(s) added [User Name: {user.UserName}])";
        //}

        //public async Task<User> GetUser()
        //{
        //    var result = await _conn.Table<User>().FirstOrDefaultAsync();

        //    return result;
        //}
    }
}
