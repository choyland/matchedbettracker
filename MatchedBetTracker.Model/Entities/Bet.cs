using System;
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace MatchedBetTracker.Model.Entities
{
    public class Bet    
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime BetDateUtc { get; set; }

        [ManyToOne]
        public BookMaker BookMaker { get; set; }
        [ForeignKey(typeof(BookMaker))]
        public int BookMakerId { get; set; }
        public double Profit { get; set; }
    }
}
