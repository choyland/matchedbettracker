using FreshMvvm;
using MatchedBetTracker.Data;
using MatchedBetTracker.Data.Interfaces;
using MatchedBetTracker.Data.Repositories.Implementation;
using MatchedBetTracker.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchedBetTracker
{
    public static class Bootstrap
    {
        public static void Run()
        {
            ConfigureContainers();
        }

        private static void ConfigureContainers()
        {
            ConfigureData();
        }

        private static void ConfigureData()
        {
            FreshIOC.Container.Register<ISQLiteImplementation, SQLiteClient>();
            FreshIOC.Container.Register<IBookMakerRepository, BookMakerRepository>();
            FreshIOC.Container.Register<IBetRepository, BetRepository>();
        }
    }
}
