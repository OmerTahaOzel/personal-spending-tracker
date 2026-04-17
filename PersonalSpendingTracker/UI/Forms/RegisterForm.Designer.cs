namespace PersonalSpendingTracker.UI.Forms
{
    partial class RegisterForm
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
            btnRegister = new Button();

            pnlCard.SuspendLayout();
            SuspendLayout();

            pnlCard.Controls.AddRange(new Control[] {
                lblTitle, lblSub, lblUser, txtUser, lblPass, txtPass, btnRegister
            });
            pnlCard.Location = new Point(50, 60);
            pnlCard.Name     = "pnlCard";
            pnlCard.Size     = new Size(380, 390);

            lblTitle.Location  = new Point(20, 20);
            lblTitle.Size      = new Size(340, 42);
            lblTitle.Text      = "Hesap Olustur";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Name      = "lblTitle";

            lblSub.Location  = new Point(20, 64);
            lblSub.Size      = new Size(340, 22);
            lblSub.Text      = "Takibe hemen basla";
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

            btnRegister.Location = new Point(20, 280);
            btnRegister.Size     = new Size(340, 48);
            btnRegister.Text     = "Kayit Ol";
            btnRegister.Name     = "btnRegister";
            btnRegister.TabIndex = 2;
            btnRegister.Click   += btnRegister_Click;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(480, 510);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox     = false;
            Name            = "RegisterForm";
            StartPosition   = FormStartPosition.CenterScreen;
            Text            = "Kayit Ol";

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
        private Button  btnRegister;
    }
}
