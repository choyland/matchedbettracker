using System;
using System.IO;
using Foundation;

namespace MatchedBetTracker.iOS.Handlers
{
    public class FileHandler
    {
        public const string DbName = "matchedBetTracker.db3";

        public const string DbNameNoExtension = "matchedBetTracker";
        public const string DbExtension = "db3";

        public static void CopyDatabaseIfNotExists()
        {
            var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            docFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(docFolder))
            {
                Directory.CreateDirectory(docFolder);
            }

            var dbPath = Path.Combine(docFolder, $"{DbNameNoExtension}.{DbExtension}");

            CopyIfNotExists(dbPath, DbNameNoExtension, DbExtension);
        }

        private static void CopyIfNotExists(string dbPath, string fileName, string fileExtension)
        {
            if (File.Exists(dbPath)) return;

            var existingDb = NSBundle.MainBundle.PathForResource(fileName, fileExtension);

            File.Copy(existingDb, dbPath);
        }
    }
}