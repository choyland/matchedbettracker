using System;
using System.IO;
using MatchedBetTracker.Data.Interfaces;
using MatchedBetTracker.Droid.SqlClient;
using MatchedBetTracker.Model.Entities;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(MatchedBetTrackerSqlClient))]
namespace MatchedBetTracker.Droid.SqlClient
{
    public class MatchedBetTrackerSqlClient : ISQLite
    {
        public SQLiteAsyncConnection SqLiteAsyncConnection { get; set; }
        private SQLiteConnectionWithLock _sqLiteConnectionWithLock;

        public MatchedBetTrackerSqlClient()
        {
            InitialiseDatabase();
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            var dbFilePath = GetDatabaseFilePath();
            var connectionFactory = new Func<SQLiteConnectionWithLock>(
                () => _sqLiteConnectionWithLock ?? (_sqLiteConnectionWithLock = new SQLiteConnectionWithLock(new SQLitePlatformAndroid(), 
                          new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: true))));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        private static string GetDatabaseFilePath()
        {
            var documentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal,
                Environment.SpecialFolderOption.Create);

            var databaseDirectoryPath = Path.Combine(documentsFolderPath, "databases");

            if (!Directory.Exists(databaseDirectoryPath)) Directory.CreateDirectory(databaseDirectoryPath);

            var databaseFilePath = Path.Combine(databaseDirectoryPath, "matchedBetTracker.db3");

            if (!File.Exists(databaseFilePath)) File.Create(databaseFilePath);

            return databaseFilePath;
        }

        private void InitialiseDatabase()
        {
            var databasePath = GetDatabaseFilePath();

            _sqLiteConnectionWithLock = new SQLiteConnectionWithLock(new SQLitePlatformAndroid(),
                new SQLiteConnectionString(databasePath, storeDateTimeAsTicks: false));
            SqLiteAsyncConnection = new SQLiteAsyncConnection(() => _sqLiteConnectionWithLock);

            CreateTables();
        }

        private void CreateTables()
        {
            SqLiteAsyncConnection.CreateTableAsync<Bet>();
            SqLiteAsyncConnection.CreateTableAsync<BookMaker>();
        }
    }
}