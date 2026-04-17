namespace PersonalSpendingTracker.UI.Forms
{
    partial class AddExpenseForm
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
            lblCat      = new Label();
            cmbCategory = new ComboBox();
            lblAmount   = new Label();
            txtAmount   = new TextBox();
            lblDate     = new Label();
            dtpDate     = new DateTimePicker();
            btnSave     = new Button();

            pnlCard.SuspendLayout();
            SuspendLayout();

            pnlCard.Controls.AddRange(new Control[] {
                lblTitle, lblCat, cmbCategory, lblAmount, txtAmount, lblDate, dtpDate, btnSave
            });
            pnlCard.Location = new Point(20, 20);
            pnlCard.Name     = "pnlCard";
            pnlCard.Size     = new Size(440, 390);

            lblTitle.Location  = new Point(20, 16);
            lblTitle.Size      = new Size(400, 36);
            lblTitle.Text      = "Yeni Harcama";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.Name      = "lblTitle";

            lblCat.AutoSize = true;
            lblCat.Location = new Point(20, 68);
            lblCat.Text     = "Kategori";
            lblCat.Name     = "lblCat";

            cmbCategory.Location = new Point(20, 90);
            cmbCategory.Size     = new Size(400, 40);
            cmbCategory.Name     = "cmbCategory";
            cmbCategory.TabIndex = 0;

            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(20, 148);
            lblAmount.Text     = "Tutar (TL)";
            lblAmount.Name     = "lblAmount";

            txtAmount.Location  = new Point(20, 170);
            txtAmount.Size      = new Size(400, 40);
            txtAmount.Name      = "txtAmount";
            txtAmount.TabIndex  = 1;
            txtAmount.TextAlign = HorizontalAlignment.Right;

            lblDate.AutoSize = true;
            lblDate.Location = new Point(20, 228);
            lblDate.Text     = "Tarih";
            lblDate.Name     = "lblDate";

            dtpDate.Location = new Point(20, 250);
            dtpDate.Size     = new Size(400, 34);
            dtpDate.Format   = DateTimePickerFormat.Short;
            dtpDate.Name     = "dtpDate";
            dtpDate.TabIndex = 2;

            btnSave.Location = new Point(20, 314);
            btnSave.Size     = new Size(400, 48);
            btnSave.Text     = "Kaydet";
            btnSave.Name     = "btnSave";
            btnSave.TabIndex = 3;
            btnSave.Click   += btnSave_Click;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(480, 432);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox     = false;
            Name            = "AddExpenseForm";
            StartPosition   = FormStartPosition.CenterParent;
            Text            = "Harcama Ekle";

            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private Panel          pnlCard;
        private Label          lblTitle;
        private Label          lblCat;
        private ComboBox       cmbCategory;
        private Label          lblAmount;
        private TextBox        txtAmount;
        private Label          lblDate;
        private DateTimePicker dtpDate;
        private Button         btnSave;
    }
}
