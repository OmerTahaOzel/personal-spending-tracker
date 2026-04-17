namespace PersonalSpendingTracker.UI.Forms
{
    partial class LoginForm
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
            pnlCard     = new Panel();
            lblTitle    = new Label();
            lblSub      = new Label();
            lblUser     = new Label();
            txtUser     = new TextBox();
            lblPass     = new Label();
            txtPass     = new TextBox();
            btnLogin    = new Button();
            btnRegister = new Button();

            pnlCard.SuspendLayout();
            SuspendLayout();

            pnlCard.Controls.AddRange(new Control[] {
                lblTitle, lblSub, lblUser, txtUser, lblPass, txtPass, btnLogin, btnRegister
            });
            pnlCard.Location = new Point(50, 60);
            pnlCard.Name     = "pnlCard";
            pnlCard.Size     = new Size(380, 440);

            lblTitle.Location  = new Point(20, 20);
            lblTitle.Size      = new Size(340, 42);
            lblTitle.Text      = "Harcama Takip";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Name      = "lblTitle";

            lblSub.Location  = new Point(20, 64);
            lblSub.Size      = new Size(340, 22);
            lblSub.Text      = "Kisisel Finans Yonetimi";
            lblSub.TextAlign = ContentAlignment.MiddleCenter;
            lblSub.Name      = "lblSub";

            lblUser.AutoSize = true;
            lblUser.Location = new Point(20, 112);
            lblUser.Text     = "Kullanici Adi";
            lblUser.Name     = "lblUser";

            txtUser.Location = new Point(20, 134);
            txtUser.Size     = new Size(340, 40);
            txtUser.Name     = "txtUser";
            txtUser.TabIndex = 0;

            lblPass.AutoSize = true;
            lblPass.Location = new Point(20, 194);
            lblPass.Text     = "Sifre";
            lblPass.Name     = "lblPass";

            txtPass.Location              = new Point(20, 216);
            txtPass.Size                  = new Size(340, 40);
            txtPass.Name                  = "txtPass";
            txtPass.UseSystemPasswordChar = true;
            txtPass.TabIndex              = 1;

            btnLogin.Location = new Point(20, 280);
            btnLogin.Size     = new Size(340, 48);
            btnLogin.Text     = "Giris Yap";
            btnLogin.Name     = "btnLogin";
            btnLogin.TabIndex = 2;
            btnLogin.Click   += btnLogin_Click;

            btnRegister.Location = new Point(20, 342);
            btnRegister.Size     = new Size(340, 40);
            btnRegister.Text     = "HesabÄ±n yok mu? Kayit Ol";
            btnRegister.Name     = "btnRegister";
            btnRegister.TabIndex = 3;
            btnRegister.Click   += btnRegister_Click;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(480, 560);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox     = false;
            Name            = "LoginForm";
            StartPosition   = FormStartPosition.CenterScreen;
            Text            = "Harcama Takip";

            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private Panel   pnlCard;
        private Label   lblTitle;
        private Label   lblSub;
        private Label   lblUser;
        private TextBox txtUser;
        private Label   lblPass;
        private TextBox txtPass;
        private Button  btnLogin;
        private Button  btnRegister;
    }
}
