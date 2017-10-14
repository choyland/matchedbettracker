using System.Collections.Generic;
using System.Threading.Tasks;
using MatchedBetTracker.Model.Entities;

namespace MatchedBetTracker.Data.Repositories.Interfaces
{
    public interface IBetRepository
    {
        Task AddBet(Bet bet);
        Task<List<Bet>> GetAll();
    }
}
