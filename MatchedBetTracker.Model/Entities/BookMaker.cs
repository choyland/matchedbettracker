using System.Collections.Generic;
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace MatchedBetTracker.Model.Entities
{
    public class BookMaker
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Bet> Bets { get; set; }
    }
}