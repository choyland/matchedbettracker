using FreshMvvm;
using MatchedBetTracker.Data.Interfaces;
using MatchedBetTracker.BusinessLayer.Factories.Interfaces;
using MatchedBetTracker.BusinessLayer.Services;
using MatchedBetTracker.Data;
using MatchedBetTracker.Data.Repositories.Implementation;
using MatchedBetTracker.Data.Repositories.Interfaces;

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
            ConfigureServices();
            ConfigureFactories();
        }

        private static void ConfigureFactories()
        {
            FreshIOC.Container.Register<IBetCalculationFactory, IBetCalculationFactory>();
        }

        private static void ConfigureServices()
        {
            FreshIOC.Container.Register<IBetService, BetService>();
        }

        private static void ConfigureData()
        {
            FreshIOC.Container.Register<ISQLiteImplementation, SQLiteClient>();
            FreshIOC.Container.Register<IBookMakerRepository, BookMakerRepository>();
            FreshIOC.Container.Register<IBetRepository, BetRepository>();
        }
    }
}
