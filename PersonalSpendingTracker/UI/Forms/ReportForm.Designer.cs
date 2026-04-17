namespace PersonalSpendingTracker.UI.Forms
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            pnlTop       = new Panel();
            pnlBtnBar    = new Panel();   // right-docked button panel inside pnlTop
            lblTitle     = new Label();
            btnBar       = new Button();
            btnPie       = new Button();
            pnlStats     = new Panel();
            lblStatTotal  = new Label();
            lblStatTotalV = new Label();
            lblStatTop    = new Label();
            lblStatTopV   = new Label();
            lblStatCount  = new Label();
            lblStatCountV = new Label();
            pnlChart     = new Panel();

            pnlTop.SuspendLayout();
            pnlBtnBar.SuspendLayout();
            pnlStats.SuspendLayout();
            SuspendLayout();
            pnlTop.Controls.Add(pnlBtnBar);   // docked Right — added first
            pnlTop.Controls.Add(lblTitle);     // docked Fill  — added second
            pnlTop.Dock   = DockStyle.Top;
            pnlTop.Height = 68;
            pnlTop.Name   = "pnlTop";
            pnlBtnBar.Controls.Add(btnPie);   // right button first
            pnlBtnBar.Controls.Add(btnBar);   // left button second
            pnlBtnBar.Dock   = DockStyle.Right;
            pnlBtnBar.Width  = 310;
            pnlBtnBar.Name   = "pnlBtnBar";
            lblTitle.Dock      = DockStyle.Fill;
            lblTitle.Text      = "Harcama Raporlari";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.Padding   = new Padding(20, 0, 0, 0);
            lblTitle.Name      = "lblTitle";
            btnBar.Dock     = DockStyle.Left;
            btnBar.Width    = 148;
            btnBar.Text     = "Sutun Grafik";
            btnBar.Name     = "btnBar";
            btnBar.TabIndex = 0;
            btnBar.Click   += btnBar_Click;
            btnPie.Dock     = DockStyle.Right;
            btnPie.Width    = 148;
            btnPie.Text     = "Pasta Grafik";
            btnPie.Name     = "btnPie";
            btnPie.TabIndex = 1;
            btnPie.Click   += btnPie_Click;
            pnlStats.Controls.AddRange(new Control[] {
                lblStatTotal, lblStatTotalV,
                lblStatTop,   lblStatTopV,
                lblStatCount, lblStatCountV
            });
            pnlStats.Dock  = DockStyle.Right;
            pnlStats.Width = 220;
            pnlStats.Name  = "pnlStats";

            lblStatTotal.AutoSize  = true; lblStatTotal.Location  = new Point(16, 24);  lblStatTotal.Name  = "lblStatTotal";  lblStatTotal.Text  = "TOPLAM HARCAMA";
            lblStatTotalV.AutoSize = true; lblStatTotalV.Location = new Point(16, 46);  lblStatTotalV.Name = "lblStatTotalV"; lblStatTotalV.Text = "₺0,00";
            lblStatTop.AutoSize    = true; lblStatTop.Location    = new Point(16, 104); lblStatTop.Name    = "lblStatTop";    lblStatTop.Text    = "EN YUKSEK";
            lblStatTopV.AutoSize   = true; lblStatTopV.Location   = new Point(16, 126); lblStatTopV.Name   = "lblStatTopV";   lblStatTopV.Text   = "—";
            lblStatTopV.MaximumSize = new Size(190, 0);
            lblStatCount.AutoSize  = true; lblStatCount.Location  = new Point(16, 184); lblStatCount.Name  = "lblStatCount";  lblStatCount.Text  = "KATEGORI SAYISI";
            lblStatCountV.AutoSize = true; lblStatCountV.Location = new Point(16, 206); lblStatCountV.Name = "lblStatCountV"; lblStatCountV.Text = "0";
            pnlChart.Dock = DockStyle.Fill;
            pnlChart.Name = "pnlChart";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(1000, 660);
            Controls.Add(pnlChart);
            Controls.Add(pnlStats);
            Controls.Add(pnlTop);
            MinimumSize   = new Size(700, 450);
            Name          = "ReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text          = "Harcama Raporlari";
            Load         += ReportForm_Load;

            pnlTop.ResumeLayout(false);
            pnlBtnBar.ResumeLayout(false);
            pnlStats.ResumeLayout(false);
            pnlStats.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private Panel  pnlTop;
        private Panel  pnlBtnBar;
        private Label  lblTitle;
        private Button btnBar;
        private Button btnPie;
        private Panel  pnlStats;
        private Label  lblStatTotal;
        private Label  lblStatTotalV;
        private Label  lblStatTop;
        private Label  lblStatTopV;
        private Label  lblStatCount;
        private Label  lblStatCountV;
        private Panel  pnlChart;
    }
}



