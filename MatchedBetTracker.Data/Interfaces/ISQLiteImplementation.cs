using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Async;

namespace MatchedBetTracker.Data.Interfaces
{
    public interface ISQLiteImplementation
    {
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
