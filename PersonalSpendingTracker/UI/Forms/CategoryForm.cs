using PersonalSpendingTracker.Utilities;
using PersonalSpendingTracker.Infrastructure.Database;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalSpendingTracker.UI.Forms
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
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
            pnlTop.BackColor    = AppTheme.Surface;
            pnlLeft.BackColor   = AppTheme.Background;
            pnlRight.BackColor  = AppTheme.Card;
            lblTitle.Font       = AppTheme.FontHead;  lblTitle.ForeColor    = AppTheme.TextPrimary; lblTitle.BackColor    = Color.Transparent;
            lblListHead.Font    = AppTheme.FontBold;  lblListHead.ForeColor = AppTheme.TextSub;     lblListHead.BackColor = Color.Transparent;
            lblAddHead.Font     = AppTheme.FontBold;  lblAddHead.ForeColor  = AppTheme.TextSub;     lblAddHead.BackColor  = Color.Transparent;
            AppTheme.ApplyListBox(lstCategories);
            AppTheme.ApplyInput(txtNewCat);
            AppTheme.ApplySuccess(btnAdd);
            AppTheme.ApplyDanger(btnDelete);
        }

        private void CategoryForm_Load(object sender, EventArgs e) => LoadList();

        private void LoadList()
        {
            lstCategories.Items.Clear();
            using var con = DbHelper.GetConnection();
            con.Open();
            using var cmd = new SQLiteCommand("SELECT Name FROM Categories ORDER BY Name", con);
            using var rd  = cmd.ExecuteReader();
            while (rd.Read()) lstCategories.Items.Add(rd.GetString(0));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var name = txtNewCat.Text.Trim();
            if (string.IsNullOrEmpty(name))
            { MessageBox.Show(Localization.Get("Err_CatEmpty"), Localization.Get("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            using var con = DbHelper.GetConnection();
            con.Open();
            using var cmd = new SQLiteCommand("INSERT OR IGNORE INTO Categories (Name) VALUES (@n)", con);
            cmd.Parameters.AddWithValue("@n", name);
            if (cmd.ExecuteNonQuery() == 0)
                MessageBox.Show(Localization.Get("Err_CatExists"), Localization.Get("Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNewCat.Clear();
            LoadList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem == null)
            { MessageBox.Show(Localization.Get("Err_DelSelectCat"), Localization.Get("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var selected = lstCategories.SelectedItem.ToString()!;
            if (MessageBox.Show(string.Format(Localization.Get("Msg_DelConfirmCat"), selected), Localization.Get("Confirm"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            using var con = DbHelper.GetConnection();
            con.Open();
            using var cmd = new SQLiteCommand("DELETE FROM Categories WHERE Name=@n", con);
            cmd.Parameters.AddWithValue("@n", selected);
            cmd.ExecuteNonQuery();
            LoadList();
        }
    }
}



