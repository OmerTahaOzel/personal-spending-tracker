using System.Data.SQLite;
using System.IO;

namespace PersonalSpendingTracker.Infrastructure.Database
{
    public class DbHelper
    {
        private static string dbFolder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                         "KisIselHarcamaTakip");

        private static string dbPath =
            Path.Combine(dbFolder, "database.db");

        private static string connStr =
            $"Data Source={dbPath};Version=3;BusyTimeout=5000;";

        public static SQLiteConnection GetConnection()
        {
            if (!Directory.Exists(dbFolder))
                Directory.CreateDirectory(dbFolder);

            return new SQLiteConnection(connStr);
        }

        public static void CreateTables()
        {
            using (var con = GetConnection())
            {
                con.Open();

                using (var cmd = new SQLiteCommand("""
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT,
                    Password TEXT
                );
                """, con)) cmd.ExecuteNonQuery();

                using (var cmd = new SQLiteCommand("""
                CREATE TABLE IF NOT EXISTS Expenses (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER,
                    Category TEXT,
                    Amount REAL,
                    Date TEXT
                );
                """, con)) cmd.ExecuteNonQuery();

                using (var cmd = new SQLiteCommand("""
                CREATE TABLE IF NOT EXISTS Categories (
                    Id   INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE
                );
                """, con)) cmd.ExecuteNonQuery();
                using (var check = new SQLiteCommand("SELECT COUNT(*) FROM Categories", con))
                {
                    long count = (long)check.ExecuteScalar();
                    if (count == 0)
                    {
                        string[] defaults = { "Food", "Transport", "Bills", "Entertainment", "Health", "Clothing", "Other" };
                        foreach (var cat in defaults)
                        {
                            using var ins = new SQLiteCommand(
                                "INSERT OR IGNORE INTO Categories (Name) VALUES (@n)", con);
                            ins.Parameters.AddWithValue("@n", cat);
                            ins.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}



