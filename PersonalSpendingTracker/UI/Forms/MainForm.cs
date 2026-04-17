using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using PersonalSpendingTracker.UI.Forms;
using PersonalSpendingTracker.Utilities;
using PersonalSpendingTracker.Infrastructure.Database;

namespace PersonalSpendingTracker
{
    public partial class MainForm : Form
    {
        public static int UserId;
        private bool _isLoggingOut = false;

        public MainForm()
        {
            InitializeComponent();
            ApplyTheme();
            AppTheme.ThemeChanged += ApplyTheme;
            Localization.ApplyToForm(this);
            Localization.LanguageChanged += ApplyLanguage;
            LoadExpenses();
        }

        private void ApplyLanguage()
        {
            Localization.ApplyToForm(this);
            ApplyDgvTranslations();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            pnlHeader.BackColor      = AppTheme.Surface;
            lblTotalCaption.Font      = AppTheme.FontSmall;
            lblTotalCaption.ForeColor = AppTheme.TextSub;
            lblTotalCaption.BackColor = Color.Transparent;
            lblTotal.Font             = AppTheme.FontBigNum;
            lblTotal.ForeColor        = AppTheme.Green;
            lblTotal.BackColor        = Color.Transparent;
            AppTheme.ApplyMenuStrip(menuStrip1);
            AppTheme.ApplyDGV(dgv);
            btnTheme.Text = AppTheme.ThemeLabel;
            AppTheme.ApplySecondary(btnTheme);
            AppTheme.ApplyDanger(btnKapat);
            if (dgv.Columns.Contains("Amount"))
            {
                dgv.Columns["Amount"].DefaultCellStyle.Format    = "N2";
                dgv.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns["Amount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            AppTheme.ThemeChanged -= ApplyTheme;
            Localization.LanguageChanged -= ApplyLanguage;
            base.OnFormClosed(e);
        }

        private void LoadExpenses()
        {
            using var con = DbHelper.GetConnection();
            con.Open();
            using var cmd = new SQLiteCommand(
                "SELECT Id AS _Id, Category, Amount, Date " +
                "FROM Expenses WHERE UserId=@u ORDER BY Date DESC", con);
            cmd.Parameters.AddWithValue("@u", UserId);
            var dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgv.DataSource = dt;
            if (dgv.Columns.Contains("_Id"))
                dgv.Columns["_Id"].Visible = false;

            if (dgv.Columns.Contains("Amount"))
            {
                dgv.Columns["Amount"].DefaultCellStyle.Format    = "N2";
                dgv.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns["Amount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            ApplyDgvTranslations();

            double total = 0;
            foreach (DataRow row in dt.Rows)
                total += Convert.ToDouble(row["Amount"]);
            lblTotal.Text = $"₺{total:N2}";
        }

        private void ApplyDgvTranslations()
        {
            if (dgv.Columns.Contains("Category")) dgv.Columns["Category"].HeaderText = Localization.Get("Col_Category");
            if (dgv.Columns.Contains("Amount")) dgv.Columns["Amount"].HeaderText = Localization.Get("Col_Amount");
            if (dgv.Columns.Contains("Date")) dgv.Columns["Date"].HeaderText = Localization.Get("Col_Date");
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show(Localization.Get("Err_DelSelectHarcama"), Localization.Get("Warning"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgv.SelectedRows[0];
            var category = row.Cells["Category"].Value?.ToString();
            var amount   = row.Cells["Amount"].Value;
            var id       = Convert.ToInt64(row.Cells["_Id"].Value);

            var confirm = MessageBox.Show(
                string.Format(Localization.Get("Msg_DelConfirmHarcama"), category, $"₺{amount:N2}"),
                Localization.Get("Confirm"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using var con = DbHelper.GetConnection();
            con.Open();
            using var cmd = new SQLiteCommand("DELETE FROM Expenses WHERE Id=@id AND UserId=@u", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@u", UserId);
            cmd.ExecuteNonQuery();

            LoadExpenses();
        }

        private void harcamaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AddExpenseForm();
            f.OnExpenseAdded += LoadExpenses;
            f.Show();
        }

        private void kategorilerToolStripMenuItem_Click(object sender, EventArgs e) =>
            new CategoryForm().ShowDialog();

        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e) =>
            new ReportForm().Show();

        private void csvAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = "CSV|*.csv", FileName = "harcamalar.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                CsvHelper.Export(sfd.FileName, UserId);
                MessageBox.Show(Localization.Get("Msg_CreatedCsv"), Localization.Get("Success"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isLoggingOut = true;
            UserId = 0;
            new LoginForm().Show();
            this.Close();
        }

        private void btnTheme_Click(object sender, EventArgs e) => AppTheme.Toggle();

        private void btnLang_Click(object sender, EventArgs e) => Localization.ToggleLanguage();

        private void btnKapat_Click(object sender, EventArgs e) => Application.Exit();

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_isLoggingOut) Application.Exit();
        }
    }
}




