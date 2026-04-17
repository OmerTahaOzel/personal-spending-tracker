using PersonalSpendingTracker.Utilities;
using PersonalSpendingTracker.Infrastructure.Database;
using System.Data.SQLite;
using System.IO;

namespace PersonalSpendingTracker.Utilities
{
    public class CsvHelper
    {
        public static void Export(string path, int userId)
        {
            using var con = DbHelper.GetConnection();
            con.Open();
            using var cmd = new SQLiteCommand(
                "SELECT Category, Amount, Date FROM Expenses WHERE UserId=@u ORDER BY Date DESC", con);
            cmd.Parameters.AddWithValue("@u", userId);
            using var rd = cmd.ExecuteReader();
            using var sw = new StreamWriter(path, false, System.Text.Encoding.UTF8);

            sw.WriteLine("Kategori,Tutar,Tarih");
            while (rd.Read())
                sw.WriteLine($"{rd[0]},{rd[1]},{rd[2]}");
        }
    }
}



