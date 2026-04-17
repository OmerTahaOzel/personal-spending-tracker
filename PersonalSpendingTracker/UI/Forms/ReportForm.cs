using PersonalSpendingTracker.Utilities;
using PersonalSpendingTracker.Infrastructure.Database;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PersonalSpendingTracker.UI.Forms
{
    public partial class ReportForm : Form
    {
        private Chart chart1 = null!;
        private enum ChartMode { Bar, Pie }
        private ChartMode currentMode = ChartMode.Bar;
        private List<string> categories = new();
        private List<double> amounts    = new();

        public ReportForm()
        {
            InitializeComponent();
            ApplyTheme();
            AppTheme.ThemeChanged += OnThemeChanged;
            Localization.ApplyToForm(this);
            Localization.LanguageChanged += ApplyLanguage;
        }

        private void ApplyLanguage() => Localization.ApplyToForm(this);

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            AppTheme.ThemeChanged -= OnThemeChanged;
            Localization.LanguageChanged -= ApplyLanguage;
            base.OnFormClosed(e);
        }

        private void OnThemeChanged()
        {
            ApplyTheme();
            if (chart1 != null) { RefreshChartTheme(); RenderChart(); }
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            pnlTop.BackColor   = AppTheme.Surface;
            pnlStats.BackColor = AppTheme.Card;
            pnlChart.BackColor = AppTheme.Background;

            lblTitle.Font = AppTheme.FontHead; lblTitle.ForeColor = AppTheme.TextPrimary; lblTitle.BackColor = Color.Transparent;

            UpdateButtonStyles();

            foreach (Label l in new[] { lblStatTotal, lblStatTop, lblStatCount })
            { l.Font = AppTheme.FontSmall; l.ForeColor = AppTheme.TextSub; l.BackColor = Color.Transparent; }

            lblStatTotalV.Font = AppTheme.FontBigNum; lblStatTotalV.ForeColor = AppTheme.Green;       lblStatTotalV.BackColor = Color.Transparent;
            lblStatTopV.Font   = AppTheme.FontBold;   lblStatTopV.ForeColor   = AppTheme.TextPrimary;  lblStatTopV.BackColor   = Color.Transparent;
            lblStatCountV.Font = AppTheme.FontBold;   lblStatCountV.ForeColor = AppTheme.Accent;       lblStatCountV.BackColor = Color.Transparent;
        }

        private void UpdateButtonStyles()
        {
            if (currentMode == ChartMode.Bar) { AppTheme.ApplyPrimary(btnBar); AppTheme.ApplySecondary(btnPie); }
            else                              { AppTheme.ApplySecondary(btnBar); AppTheme.ApplyPrimary(btnPie); }
        }

        private void RefreshChartTheme()
        {
            chart1.BackColor = AppTheme.Background;
            var ca = chart1.ChartAreas["main"];
            ca.BackColor = AppTheme.Surface;
            ca.BorderColor = AppTheme.Border;
            ca.AxisX.LabelStyle.ForeColor = AppTheme.TextSub;
            ca.AxisX.LineColor            = AppTheme.Border;
            ca.AxisY.LabelStyle.ForeColor = AppTheme.TextSub;
            ca.AxisY.LineColor            = AppTheme.Border;
            ca.AxisY.MajorGrid.LineColor  = AppTheme.Border;
            chart1.Legends["main"].BackColor = AppTheme.Card;
            chart1.Legends["main"].ForeColor = AppTheme.TextPrimary;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            BuildChart();
            LoadData();
            RenderChart();
        }

        private void BuildChart()
        {
            chart1 = new Chart { Dock = DockStyle.Fill };
            chart1.BackColor      = AppTheme.Background;
            chart1.BorderlineColor = AppTheme.Border;
            chart1.Palette        = ChartColorPalette.None;

            var ca = new ChartArea("main");
            ca.BackColor  = AppTheme.Surface;
            ca.BorderColor = AppTheme.Border;

            ca.AxisX.LabelStyle.ForeColor    = AppTheme.TextSub;
            ca.AxisX.LabelStyle.Font         = AppTheme.FontSmall;
            ca.AxisX.LineColor               = AppTheme.Border;
            ca.AxisX.MajorGrid.LineWidth     = 0;
            ca.AxisX.MajorTickMark.LineColor = AppTheme.Border;

            ca.AxisY.LabelStyle.ForeColor    = AppTheme.TextSub;
            ca.AxisY.LabelStyle.Font         = AppTheme.FontSmall;
            ca.AxisY.LabelStyle.Format       = "N0";
            ca.AxisY.LineColor               = AppTheme.Border;
            ca.AxisY.MajorGrid.LineColor     = AppTheme.Border;
            ca.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            ca.AxisY.MajorTickMark.LineColor = AppTheme.Border;
            chart1.ChartAreas.Add(ca);

            var legend = new Legend("main");
            legend.BackColor   = AppTheme.Card;
            legend.ForeColor   = AppTheme.TextPrimary;
            legend.Font        = AppTheme.FontSmall;
            legend.BorderColor = AppTheme.Border;
            legend.Docking     = Docking.Bottom;
            chart1.Legends.Add(legend);

            pnlChart.Controls.Add(chart1);
        }

        private void LoadData()
        {
            categories.Clear();
            amounts.Clear();

            using var con = DbHelper.GetConnection();
            con.Open();
            using var cmd = new SQLiteCommand(
                @"SELECT Category, SUM(Amount) AS Total
                  FROM Expenses WHERE UserId=@u
                  GROUP BY Category ORDER BY Total DESC", con);
            cmd.Parameters.AddWithValue("@u", MainForm.UserId);
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                categories.Add(rd.GetString(0));
                amounts.Add(rd.GetDouble(1));
            }

            double total = amounts.Sum();
            lblStatTotalV.Text = $"₺{total:N2}";
            lblStatTopV.Text   = categories.Count > 0 ? categories[0] : "—";
            lblStatCountV.Text = categories.Count.ToString();
        }

        private void RenderChart()
        {
            if (chart1 == null || categories.Count == 0) return;
            chart1.Series.Clear();

            if (currentMode == ChartMode.Bar) RenderBar();
            else RenderPie();
        }

        private void RenderBar()
        {
            var ca = chart1.ChartAreas["main"];
            ca.AxisX.LabelStyle.ForeColor    = AppTheme.TextSub;
            ca.AxisY.LabelStyle.ForeColor    = AppTheme.TextSub;
            ca.AxisX.LineColor               = AppTheme.Border;
            ca.AxisY.LineColor               = AppTheme.Border;
            ca.AxisX.MajorGrid.LineWidth     = 0;
            ca.AxisY.MajorGrid.LineWidth     = 1;
            ca.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            ca.AxisX.MajorTickMark.LineWidth = 1;
            ca.AxisY.MajorTickMark.LineWidth = 1;
            chart1.Legends["main"].Enabled   = false;
            var s = new Series("Harcamalar");
            s.ChartType           = SeriesChartType.Column;
            s.ChartArea           = "main";
            s.IsValueShownAsLabel = true;
            s.LabelFormat         = "N0";
            s.LabelForeColor      = AppTheme.TextPrimary;
            s.Font                = AppTheme.FontSmall;

            for (int i = 0; i < categories.Count; i++)
            {
                int idx = s.Points.AddXY(categories[i], amounts[i]);
                s.Points[idx].Color       = AppTheme.ChartColors[i % AppTheme.ChartColors.Length];
                s.Points[idx].BorderColor = Color.Transparent;
                s.Points[idx].BorderWidth = 0;
            }

            chart1.Series.Add(s);
            chart1.ChartAreas["main"].RecalculateAxesScale();
        }

        private void RenderPie()
        {
            var ca = chart1.ChartAreas["main"];
            ca.AxisX.LabelStyle.ForeColor    = Color.Transparent;
            ca.AxisY.LabelStyle.ForeColor    = Color.Transparent;
            ca.AxisX.LineColor               = Color.Transparent;
            ca.AxisY.LineColor               = Color.Transparent;
            ca.AxisX.MajorGrid.LineWidth     = 0;
            ca.AxisY.MajorGrid.LineWidth     = 0;
            ca.AxisX.MajorTickMark.LineWidth = 0;
            ca.AxisY.MajorTickMark.LineWidth = 0;
            chart1.Legends["main"].Enabled   = true;

            var s = new Series("Harcamalar");
            s.ChartType = SeriesChartType.Pie;
            s.ChartArea = "main";
            s.Legend    = "main";

            double total = amounts.Sum();
            for (int i = 0; i < categories.Count; i++)
            {
                int idx = s.Points.AddXY(categories[i], amounts[i]);
                double pct = total > 0 ? amounts[i] / total * 100 : 0;
                s.Points[idx].Color          = AppTheme.ChartColors[i % AppTheme.ChartColors.Length];
                s.Points[idx].LabelForeColor = AppTheme.TextPrimary;
                s.Points[idx].Font           = AppTheme.FontSmall;
                s.Points[idx].Label          = $"{pct:N1}%";
                s.Points[idx].LegendText     = $"{categories[i]}  ₺{amounts[i]:N0}";
            }

            chart1.Series.Add(s);
        }

        private void btnBar_Click(object sender, EventArgs e)
        {
            currentMode = ChartMode.Bar;
            UpdateButtonStyles();
            RenderChart();
        }

        private void btnPie_Click(object sender, EventArgs e)
        {
            currentMode = ChartMode.Pie;
            UpdateButtonStyles();
            RenderChart();
        }
    }
}





