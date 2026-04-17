namespace PersonalSpendingTracker
{
    partial class MainForm
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
            menuStrip1                   = new MenuStrip();
            harcamaEkleToolStripMenuItem = new ToolStripMenuItem();
            kategorilerToolStripMenuItem = new ToolStripMenuItem();
            raporlarToolStripMenuItem    = new ToolStripMenuItem();
            csvAktarToolStripMenuItem    = new ToolStripMenuItem();
            logoutToolStripMenuItem      = new ToolStripMenuItem();
            silToolStripMenuItem          = new ToolStripMenuItem();
            btnLang                      = new ToolStripMenuItem();
            pnlHeader                    = new Panel();
            lblTotalCaption              = new Label();
            lblTotal                     = new Label();
            btnTheme                     = new Button();
            btnKapat                     = new Button();
            dgv                          = new DataGridView();

            menuStrip1.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            menuStrip1.Items.AddRange(new ToolStripItem[] {
                harcamaEkleToolStripMenuItem,
                kategorilerToolStripMenuItem,
                raporlarToolStripMenuItem,
                csvAktarToolStripMenuItem,
                silToolStripMenuItem,
                logoutToolStripMenuItem,
                btnLang
            });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name     = "menuStrip1";
            menuStrip1.Size     = new Size(1000, 28);

            harcamaEkleToolStripMenuItem.Name   = "harcamaEkleToolStripMenuItem";
            harcamaEkleToolStripMenuItem.Text   = "Harcama Ekle";
            harcamaEkleToolStripMenuItem.Click += harcamaEkleToolStripMenuItem_Click;

            kategorilerToolStripMenuItem.Name   = "kategorilerToolStripMenuItem";
            kategorilerToolStripMenuItem.Text   = "Kategoriler";
            kategorilerToolStripMenuItem.Click += kategorilerToolStripMenuItem_Click;

            raporlarToolStripMenuItem.Name   = "raporlarToolStripMenuItem";
            raporlarToolStripMenuItem.Text   = "Raporlar";
            raporlarToolStripMenuItem.Click += raporlarToolStripMenuItem_Click;

            csvAktarToolStripMenuItem.Name   = "csvAktarToolStripMenuItem";
            csvAktarToolStripMenuItem.Text   = "Disa Aktar";
            csvAktarToolStripMenuItem.Click += csvAktarToolStripMenuItem_Click;

            silToolStripMenuItem.Name   = "silToolStripMenuItem";
            silToolStripMenuItem.Text   = "Harcama Sil";
            silToolStripMenuItem.Click += silToolStripMenuItem_Click;

            logoutToolStripMenuItem.Name   = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Text   = "Oturumu Kapat";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            btnLang.Name   = "btnLang";
            btnLang.Text   = "Language: EN";
            btnLang.Click += btnLang_Click;
            pnlHeader.Controls.AddRange(new Control[] {
                lblTotalCaption, lblTotal, btnTheme, btnKapat
            });
            pnlHeader.Dock   = DockStyle.Top;
            pnlHeader.Height = 80;
            pnlHeader.Name   = "pnlHeader";

            lblTotalCaption.AutoSize = true;
            lblTotalCaption.Location = new Point(24, 14);
            lblTotalCaption.Name     = "lblTotalCaption";
            lblTotalCaption.Text     = "TOPLAM HARCAMA";

            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(22, 38);
            lblTotal.Name     = "lblTotal";
            lblTotal.Text     = "₺0,00";

            btnTheme.Anchor   = AnchorStyles.Top | AnchorStyles.Right;
            btnTheme.Location = new Point(740, 20);
            btnTheme.Size     = new Size(140, 40);
            btnTheme.Name     = "btnTheme";
            btnTheme.Text     = "Açık Tema";
            btnTheme.TabIndex = 0;
            btnTheme.Click   += btnTheme_Click;

            btnKapat.Anchor   = AnchorStyles.Top | AnchorStyles.Right;
            btnKapat.Location = new Point(892, 20);
            btnKapat.Size     = new Size(88, 40);
            btnKapat.Name     = "btnKapat";
            btnKapat.Text     = "Kapat";
            btnKapat.TabIndex = 1;
            btnKapat.Click   += btnKapat_Click;
            dgv.Anchor   = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv.Location = new Point(0, 108);
            dgv.Name     = "dgv";
            dgv.Size     = new Size(1000, 512);
            dgv.TabIndex = 1;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(1000, 620);
            Controls.Add(dgv);
            Controls.Add(pnlHeader);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize   = new Size(800, 500);
            Name          = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text          = "Kişisel Harcama Takip";
            FormClosed   += MainForm_FormClosed;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private MenuStrip         menuStrip1;
        private ToolStripMenuItem harcamaEkleToolStripMenuItem;
        private ToolStripMenuItem kategorilerToolStripMenuItem;
        private ToolStripMenuItem raporlarToolStripMenuItem;
        private ToolStripMenuItem csvAktarToolStripMenuItem;
        private ToolStripMenuItem silToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem btnLang;
        private Panel             pnlHeader;
        private Label             lblTotalCaption;
        private Label             lblTotal;
        private Button            btnTheme;
        private Button            btnKapat;
        private DataGridView      dgv;
    }
}


