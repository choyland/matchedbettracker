using System.Collections.Generic;
using System.Threading.Tasks;
using MatchedBetTracker.Data.Interfaces;
using MatchedBetTracker.Data.Repositories.Interfaces;
using MatchedBetTracker.Model.Entities;
using SQLiteNetExtensionsAsync.Extensions;

namespace MatchedBetTracker.Data.Repositories.Implementation
{
    public class BookMakerRepository : BaseRepository, IBookMakerRepository
    {
        private readonly ISQLiteImplementation _sqLiteImplementation;
        public string StatusMessage { get; set; }

        public BookMakerRepository(ISQLiteImplementation sqLiteImplementation)
        {
            _sqLiteImplementation = sqLiteImplementation;
        }

        public async Task<List<BookMaker>> GetAllBookMakers()
        {
            using (await Locker.LockAsync())
            {
                var connection = _sqLiteImplementation.GetAsyncConnection();

                var bookMakers = await connection.Table<BookMaker>().ToListAsync();

                return bookMakers;
            }
        }

        public async Task<List<BookMaker>> GetAllBookMakersWithBets()
        {
            using (await Locker.LockAsync())
            {
                var connection = _sqLiteImplementation.GetAsyncConnection();

                var bookMakers = await connection.GetAllWithChildrenAsync<BookMaker>();

                return bookMakers;
            }
        }

        public async Task AddBookMaker(BookMaker bookMaker)
        {
            using (await Locker.LockAsync())
            {
                var connection = _sqLiteImplementation.GetAsyncConnection();

                await connection.InsertOrReplaceWithChildrenAsync(bookMaker);
            }
        }

        public async Task UpdateBookMaker(BookMaker bookMaker)
        {
            using (await Locker.LockAsync())
            {
                var connection = _sqLiteImplementation.GetAsyncConnection();

                await connection.UpdateWithChildrenAsync(bookMaker);
            }
        }
    }
}
