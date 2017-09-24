using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchedBetTracker.BusinessLayer.ViewModels
{
    public class BetViewModel
    {
        public int Id { get; set; }

        public DateTime BetDateUtc { get; set; }
        
        public BookMakerViewModel BookMaker { get; set; }
        
        public int BookMakerId { get; set; }

        public double Profit { get; set; }
    }
}
