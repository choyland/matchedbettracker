using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchedBetTracker.Data.Repositories.Interfaces;
using MatchedBetTracker.Model.Entities;

namespace MatchedBetTracker.BusinessLayer.Services
{
    public class BetService : IBetService
    {
        private readonly IBetRepository _betRepository;

        public BetService(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }

        public async Task AddBet(Bet bet)
        {
            await _betRepository.AddBet(bet);
        }
    }
}
