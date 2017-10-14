using System.Threading.Tasks;
using MatchedBetTracker.BusinessLayer.ViewModels;
using MatchedBetTracker.Model.Enum;

namespace MatchedBetTracker.BusinessLayer.Services.Interfaces
{
    public interface IBetService
    {
        Task AddBet(BetViewModel bet);

        BetCalculationViewModel CalculateBet(BetType betType, double backStake, double backOdds, double layOdds, double layCommission);
    }
}
