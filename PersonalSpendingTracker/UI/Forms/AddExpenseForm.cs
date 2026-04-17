using PersonalSpendingTracker.Utilities;
using PersonalSpendingTracker.Infrastructure.Database;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalSpendingTracker.UI.Forms
{
    public partial class AddExpenseForm : Form
    {
        public delegate void ExpenseAdded();
        public event ExpenseAdded? OnExpenseAdded;

        public AddExpenseForm()
        {
            InitializeComponent();
            ApplyTheme();
            AppTheme.ThemeChanged += ApplyTheme;
            Localization.ApplyToForm(this);
            Localization.LanguageChanged += ApplyLanguage;
            LoadCategories();
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
            lblTitle.Font      = AppTheme.FontHead; lblTitle.ForeColor = AppTheme.TextPrimary; lblTitle.BackColor = Color.Transparent;
            foreach (Label l in new[] { lblCat, lblAmount, lblDate })
            { l.Font = AppTheme.FontBold; l.ForeColor = AppTheme.TextSub; l.BackColor = Color.Transparent; }
            AppTheme.ApplyCombo(cmbCategory);
            AppTheme.ApplyInput(txtAmount);
            dtpDate.BackColor              = AppTheme.InputBg;
            dtpDate.ForeColor              = AppTheme.TextPrimary;
            dtpDate.CalendarMonthBackground = AppTheme.Card;
            dtpDate.CalendarForeColor      = AppTheme.TextPrimary;
            dtpDate.CalendarTitleBackColor = AppTheme.Accent;
            dtpDate.CalendarTitleForeColor = Color.White;
            dtpDate.Font                   = AppTheme.FontInput;
            AppTheme.ApplySuccess(btnSave);
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            using var con = DbHelper.GetConnection();
            con.Open();
            using var cmd = new SQLiteCommand("SELECT Name FROM Categories ORDER BY Name", con);
            using var rd  = cmd.ExecuteReader();
            while (rd.Read()) cmbCategory.Items.Add(rd.GetString(0));
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem == null)
            { MessageBox.Show(Localization.Get("Err_SelectCat"), Localization.Get("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!double.TryParse(txtAmount.Text.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double amount) || amount <= 0)
            { MessageBox.Show(Localization.Get("Err_InvalidAmount"), Localization.Get("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            using var con = DbHelper.GetConnection();
            con.Open();
            using var cmd = new SQLiteCommand(
                "INSERT INTO Expenses (UserId, Category, Amount, Date) VALUES (@u, @c, @a, @d)", con);
            cmd.Parameters.AddWithValue("@u", MainForm.UserId);
            cmd.Parameters.AddWithValue("@c", cmbCategory.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@a", amount);
            cmd.Parameters.AddWithValue("@d", dtpDate.Value.ToString("yyyy-MM-dd"));
            cmd.ExecuteNonQuery();

            OnExpenseAdded?.Invoke();
            this.Close();
        }
    }
}



