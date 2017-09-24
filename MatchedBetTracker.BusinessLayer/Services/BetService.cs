using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MatchedBetTracker.BusinessLayer.ViewModels;
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
    }
}
