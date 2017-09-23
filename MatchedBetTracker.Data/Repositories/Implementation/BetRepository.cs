using System.Threading.Tasks;
using MatchedBetTracker.Data.Interfaces;
using MatchedBetTracker.Data.Repositories.Interfaces;
using MatchedBetTracker.Model.Entities;
using SQLiteNetExtensionsAsync.Extensions;

namespace MatchedBetTracker.Data.Repositories.Implementation
{
    public class BetRepository : BaseRepository, IBetRepository
    {
        private readonly ISQLiteImplementation _sqLiteImplementation;
        public string StatusMessage { get; set; }

        public BetRepository(ISQLiteImplementation sqLiteImplementation)
        {
            _sqLiteImplementation = sqLiteImplementation;
        }

        public async Task AddBet(Bet bet)
        {
            using (await Locker.LockAsync())
            {
                var connection = _sqLiteImplementation.GetAsyncConnection();

                await connection.InsertOrReplaceWithChildrenAsync(bet);
            }
        }
    }
}