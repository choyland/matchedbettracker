using MatchedBetTracker.Data.Interfaces;
using MatchedBetTracker.Data.Repositories.Interfaces;

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
    }
}