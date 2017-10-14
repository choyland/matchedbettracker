using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchedBetTracker.BusinessLayer.Services.Interfaces;
using MatchedBetTracker.BusinessLayer.ViewModels;
using MatchedBetTracker.Data.Repositories.Interfaces;
using MatchedBetTracker.Model.Entities;

namespace MatchedBetTracker.BusinessLayer.Services.Implementation
{
    public class BookmakerService : IBookmakerService
    {
        private readonly IBookMakerRepository _bookMakerRepository;

        public BookmakerService(IBookMakerRepository bookMakerRepository)
        {
            _bookMakerRepository = bookMakerRepository;
        }

        public async Task<List<BookMakerViewModel>> GetAllBookmakers()
        {
            var allBookmakers = await _bookMakerRepository.GetAllBookMakers();

            if (allBookmakers == null || !allBookmakers.Any())
            {
                return new List<BookMakerViewModel>();
            }

            var bookmakerViewModels = allBookmakers.Select(bm => AutoMapper.Mapper.Map<BookMakerViewModel>(bm));

            return bookmakerViewModels.ToList();
        }
    }
}
