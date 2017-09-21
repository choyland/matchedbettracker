using System;
using SQLite;

namespace MatchedBetTracker.Model.Entities
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime JoinedDate { get; set; }
    }
}
