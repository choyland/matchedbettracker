using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchedBetTracker.Model.Entities;

namespace MatchedBetTracker.BusinessLayer.Services
{
    public interface IBetService
    {
        Task AddBet(Bet bet);
    }
}
