using System.Threading.Tasks;
using MatchedBetTracker.BusinessLayer.Factories.Interfaces;
using MatchedBetTracker.BusinessLayer.ViewModels;
using MatchedBetTracker.Data.Repositories.Interfaces;
using MatchedBetTracker.Model.Entities;
using MatchedBetTracker.Model.Enum;

namespace MatchedBetTracker.BusinessLayer.Services
{
    public class BetService : IBetService
    {
        private readonly IBetRepository _betRepository;
        private readonly IBetCalculationFactory _betCalculationFactory;

        public BetService(IBetRepository betRepository, IBetCalculationFactory betCalculationFactory)
        {
            _betRepository = betRepository;
            _betCalculationFactory = betCalculationFactory;
        }

        public async Task AddBet(BetViewModel betViewModel)
        {
            var betEntity = new Bet
            {
                BetDateUtc = betViewModel.BetDateUtc,
                BookMaker = new BookMaker
                {
                    Name = betViewModel.BookMaker.Name
                },
                Profit = betViewModel.Profit
            };

            await _betRepository.AddBet(betEntity);
        }

        public BetCalculationViewModel CalculateBet(BetType betType, double backStake, double backOdds, double layOdds,
            double layCommission)
        {
            var decimalLayCommission = layCommission / 100;

            var betCalcFactory = _betCalculationFactory.GetCalculator(betType);

            var calculation = betCalcFactory.Calculate(backStake, backOdds, layOdds, decimalLayCommission);

            return new BetCalculationViewModel
            {
                LayStake = calculation.LayStake,
                BookMakerWinProfit = calculation.BookMakerWinProfit,
                ExchangeWinProfit = calculation.ExchangeWinProfit,
                Liability = calculation.Liability
            };
        }
    }
}
