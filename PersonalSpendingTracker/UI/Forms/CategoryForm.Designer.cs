namespace PersonalSpendingTracker.UI.Forms
{
    partial class CategoryForm
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
            pnlTop        = new Panel();
            lblTitle      = new Label();
            pnlLeft       = new Panel();
            lblListHead   = new Label();
            lstCategories = new ListBox();
            pnlRight      = new Panel();
            lblAddHead    = new Label();
            txtNewCat     = new TextBox();
            btnAdd        = new Button();
            btnDelete     = new Button();

            pnlTop.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            SuspendLayout();

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock   = DockStyle.Top;
            pnlTop.Height = 60;
            pnlTop.Name   = "pnlTop";

            lblTitle.Location  = new Point(20, 12);
            lblTitle.Size      = new Size(460, 36);
            lblTitle.Text      = "Kategori Yonetimi";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.Name      = "lblTitle";

            pnlLeft.Controls.AddRange(new Control[] { lblListHead, lstCategories });
            pnlLeft.Dock    = DockStyle.Left;
            pnlLeft.Width   = 260;
            pnlLeft.Name    = "pnlLeft";

            lblListHead.AutoSize = true;
            lblListHead.Location = new Point(16, 12);
            lblListHead.Text     = "Mevcut Kategoriler";
            lblListHead.Name     = "lblListHead";

            lstCategories.Location = new Point(16, 36);
            lstCategories.Size     = new Size(228, 300);
            lstCategories.Anchor   = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstCategories.Name     = "lstCategories";

            pnlRight.Controls.AddRange(new Control[] { lblAddHead, txtNewCat, btnAdd, btnDelete });
            pnlRight.Dock  = DockStyle.Fill;
            pnlRight.Name  = "pnlRight";

            lblAddHead.AutoSize = true;
            lblAddHead.Location = new Point(16, 12);
            lblAddHead.Text     = "Yeni Kategori";
            lblAddHead.Name     = "lblAddHead";

            txtNewCat.Location = new Point(16, 36);
            txtNewCat.Size     = new Size(210, 40);
            txtNewCat.Name     = "txtNewCat";
            txtNewCat.TabIndex = 0;

            btnAdd.Location = new Point(16, 94);
            btnAdd.Size     = new Size(210, 44);
            btnAdd.Text     = "Ekle";
            btnAdd.Name     = "btnAdd";
            btnAdd.TabIndex = 1;
            btnAdd.Click   += btnAdd_Click;

            btnDelete.Location = new Point(16, 188);
            btnDelete.Size     = new Size(210, 44);
            btnDelete.Text     = "Seciliyi Sil";
            btnDelete.Name     = "btnDelete";
            btnDelete.TabIndex = 2;
            btnDelete.Click   += btnDelete_Click;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(520, 420);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false; MinimizeBox = false;
            Name            = "CategoryForm";
            StartPosition   = FormStartPosition.CenterParent;
            Text            = "Kategori Yonetimi";
            Load           += CategoryForm_Load;

            pnlTop.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private Panel   pnlTop;
        private Label   lblTitle;
        private Panel   pnlLeft;
        private Label   lblListHead;
        private ListBox lstCategories;
        private Panel   pnlRight;
        private Label   lblAddHead;
        private TextBox txtNewCat;
        private Button  btnAdd;
        private Button  btnDelete;
    }
}

