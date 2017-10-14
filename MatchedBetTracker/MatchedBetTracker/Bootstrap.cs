using FreshMvvm;
using MatchedBetTracker.BusinessLayer.Factories.Implementation;
using MatchedBetTracker.Data.Interfaces;
using MatchedBetTracker.BusinessLayer.Factories.Interfaces;
using MatchedBetTracker.BusinessLayer.Mapper;
using MatchedBetTracker.BusinessLayer.Providers.Implementation;
using MatchedBetTracker.BusinessLayer.Providers.Interfaces;
using MatchedBetTracker.BusinessLayer.Services.Implementation;
using MatchedBetTracker.BusinessLayer.Services.Interfaces;
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
            ConfigureProviders();
            AutoMapper();

        }

        private static void ConfigureProviders()
        {
            FreshIOC.Container.Register<IDateTimeProvider, DateTimeProvider>();
        }

        private static void AutoMapper()
        {
            InitializeAutoMapper.Initialize();
        }

        private static void ConfigureFactories()
        {
            FreshIOC.Container.Register<IBetCalculationFactory, BetCalculationFactory>();
        }

        private static void ConfigureServices()
        {
            FreshIOC.Container.Register<IBetService, BetService>();
            FreshIOC.Container.Register<IBookmakerService, BookmakerService>();
        }

        private static void ConfigureData()
        {
            FreshIOC.Container.Register<ISQLiteImplementation, SQLiteClient>();
            FreshIOC.Container.Register<IBookMakerRepository, BookMakerRepository>();
            FreshIOC.Container.Register<IBetRepository, BetRepository>();
        }
    }
}
