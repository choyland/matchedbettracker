using System.Collections.Generic;
using MatchedBetTracker.BusinessLayer.ServiceModels;
using MatchedBetTracker.BusinessLayer.ViewModels;
using MatchedBetTracker.Model.Entities;
using Microsoft.VisualBasic.CompilerServices;

namespace MatchedBetTracker.BusinessLayer.Mapper
{
    public static class InitializeAutoMapper
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Bet, BetViewModel>()
                .ForMember(dest => dest.BookMaker, opt => opt.MapFrom(s => AutoMapper.Mapper.Map<BookMaker, BookMakerViewModel>(s.BookMaker)))
                .ReverseMap();

                cfg.CreateMap<BetCalculationViewModel, BetCalculationModel>().ReverseMap();
            });
        }
    }
}
