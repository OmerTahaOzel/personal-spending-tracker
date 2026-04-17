using PersonalSpendingTracker.Utilities;
using PersonalSpendingTracker.Infrastructure.Database;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalSpendingTracker.UI.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            ApplyTheme();
            AppTheme.ThemeChanged += ApplyTheme;
            Localization.ApplyToForm(this);
            Localization.LanguageChanged += ApplyLanguage;
        }

        private void ApplyLanguage() => Localization.ApplyToForm(this);

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            AppTheme.ThemeChanged -= ApplyTheme;
            Localization.LanguageChanged -= ApplyLanguage;
            base.OnFormClosed(e);
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            pnlCard.BackColor  = AppTheme.Surface;
            lblTitle.Font      = AppTheme.FontLarge;  lblTitle.ForeColor = AppTheme.TextPrimary; lblTitle.BackColor = Color.Transparent;
            lblSub.Font        = AppTheme.FontSub;    lblSub.ForeColor   = AppTheme.TextSub;     lblSub.BackColor   = Color.Transparent;
            lblUser.Font       = AppTheme.FontBold;   lblUser.ForeColor  = AppTheme.TextSub;     lblUser.BackColor  = Color.Transparent;
            lblPass.Font       = AppTheme.FontBold;   lblPass.ForeColor  = AppTheme.TextSub;     lblPass.BackColor  = Color.Transparent;
            AppTheme.ApplyInput(txtUser);
            AppTheme.ApplyInput(txtPass);
            AppTheme.ApplySuccess(btnRegister);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            { MessageBox.Show(Localization.Get("Err_EmptyFields"), Localization.Get("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            using var con = DbHelper.GetConnection();
            con.Open();
            using var cmd = new SQLiteCommand("INSERT INTO Users (Username, Password) VALUES (@u, @p)", con);
            cmd.Parameters.AddWithValue("@u", txtUser.Text.Trim());
            cmd.Parameters.AddWithValue("@p", txtPass.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show(Localization.Get("Msg_RegSuccess"), Localization.Get("Success"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}



