using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using MatchedBetTracker.BusinessLayer.ViewModels;
using MatchedBetTracker.Data.Repositories.Interfaces;
using MatchedBetTracker.Model.Entities;
using Xamarin.Forms;

namespace MatchedBetTracker.PageModels
{
    public class AddBetPageModel : FreshBasePageModel
    {
        private readonly BusinessLayer.Services.IBetService _betService;

        public AddBetPageModel(BusinessLayer.Services.IBetService betService)
        {
            _betService = betService;
        }

        public override void Init(object initData)
        {
            base.Init(initData);
        }

        public ICommand AddBetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _betService.AddBet(new BetViewModel
                    {
                        BetDateUtc = DateTime.UtcNow,
                        BookMaker = new BookMakerViewModel
                        {
                            Name = "Ladbrokes"
                        },
                        Profit = 10.20
                    });
                });
            }
        }
    }
}
