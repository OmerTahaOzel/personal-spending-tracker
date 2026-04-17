using PersonalSpendingTracker.UI.Forms;
using PersonalSpendingTracker.Utilities;
using System;
using PersonalSpendingTracker.Infrastructure.Database;
using System.Windows.Forms;

namespace PersonalSpendingTracker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Localization.LoadLanguage();
            DbHelper.CreateTables();
            Application.Run(new LoginForm());
        }
    }
}


