using System;
using System.IO;
using MatchedBetTracker.Data.Interfaces;
using MatchedBetTracker.iOS.Handlers;
using MatchedBetTracker.Model.Entities;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinIOS;

namespace MatchedBetTracker.iOS.SqlClient
{
    public class MatchedBetTrackerSqlClient : ISQLite
    {
        public SQLiteAsyncConnection SqLiteAsyncConnection { get; set; }
        private SQLite.Net.SQLiteConnectionWithLock _sqLiteConnectionWithLock;

        public MatchedBetTrackerSqlClient()
        {
            InitialiseDatabase();
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            var dbPath = GetDatabaseFilePath();

            var platForm = new SQLitePlatformIOS();

            var connectionFactory = new Func<SQLiteConnectionWithLock>(
                () => _sqLiteConnectionWithLock ?? (_sqLiteConnectionWithLock = new SQLiteConnectionWithLock(
                          platForm,
                          new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: true))));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        private string GetDatabaseFilePath()
        {
            var documentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal,
                Environment.SpecialFolderOption.Create);

            var databaseDirectoryPath = Path.Combine(documentsFolderPath, "..", "Library", "Databases");

            if (!Directory.Exists(databaseDirectoryPath)) Directory.CreateDirectory(databaseDirectoryPath);

            var databaseFilePath = Path.Combine(databaseDirectoryPath, $"{FileHandler.DbNameNoExtension}.{FileHandler.DbExtension}");

            if (!File.Exists(databaseFilePath)) File.Create(databaseFilePath);

            return databaseFilePath;
        }

        private void InitialiseDatabase()
        {
            var databasePath = GetDatabaseFilePath();

            _sqLiteConnectionWithLock = new SQLiteConnectionWithLock(new SQLitePlatformIOS(),
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