using System.Collections.Generic;
using System.Threading.Tasks;
using MatchedBetTracker.Model.Entities;

namespace MatchedBetTracker.Data.Repositories.Interfaces
{
    public interface IBookMakerRepository
    {
        Task<List<BookMaker>> GetAllBookMakers();
        Task<List<BookMaker>> GetAllBookMakersWithBets();
        Task AddBookMaker(BookMaker bookMaker);
        Task UpdateBookMaker(BookMaker bookMaker);
    }
}
