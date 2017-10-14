using System;
using System.Windows.Input;
using FreshMvvm;
using MatchedBetTracker.BusinessLayer.Providers.Interfaces;
using MatchedBetTracker.BusinessLayer.Services.Interfaces;
using MatchedBetTracker.BusinessLayer.ViewModels;
using Xamarin.Forms;

namespace MatchedBetTracker.PageModels
{
    public class AddBetPageModel : FreshBasePageModel
    {
        private readonly IBetService _betService;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AddBetPageModel(IBetService betService, IDateTimeProvider dateTimeProvider)
        {
            _betService = betService;
            _dateTimeProvider = dateTimeProvider;
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
                        BetDateUtc = _dateTimeProvider.GetDateTimeNowUtc(),
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
