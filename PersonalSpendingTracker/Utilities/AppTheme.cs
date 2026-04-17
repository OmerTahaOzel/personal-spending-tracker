using System.Drawing;
using System.Windows.Forms;

namespace PersonalSpendingTracker.Utilities
{
    public static class AppTheme
    {
        public static bool IsDark = false;
        public static event Action? ThemeChanged;

        public static void Toggle()
        {
            IsDark = !IsDark;
            ThemeChanged?.Invoke();
        }

        public static string ThemeLabel => IsDark ? Localization.Get("ThemeLight") : Localization.Get("ThemeDark");
        public static Color Background  => IsDark ? Color.FromArgb(10,  10,  10)  : Color.FromArgb(245, 245, 248);
        public static Color Surface     => IsDark ? Color.FromArgb(20,  20,  20)  : Color.White;
        public static Color Card        => IsDark ? Color.FromArgb(30,  30,  30)  : Color.FromArgb(234, 234, 240);
        public static Color CardHover   => IsDark ? Color.FromArgb(42,  42,  42)  : Color.FromArgb(220, 220, 230);
        public static Color TextPrimary => IsDark ? Color.FromArgb(240, 240, 240) : Color.FromArgb(17,  17,  34);
        public static Color TextSub     => IsDark ? Color.FromArgb(140, 140, 140) : Color.FromArgb(100, 100, 120);
        public static Color Border      => IsDark ? Color.FromArgb(55,  55,  55)  : Color.FromArgb(210, 210, 220);
        public static Color InputBg     => IsDark ? Color.FromArgb(18,  18,  18)  : Color.White;
        public static readonly Color Accent      = Color.FromArgb(99, 102, 241);
        public static readonly Color AccentHover = Color.FromArgb(118, 120, 250);
        public static readonly Color AccentDark  = Color.FromArgb(79, 70, 229);
        public static readonly Color Green       = Color.FromArgb(16, 185, 129);
        public static readonly Color GreenHover  = Color.FromArgb(52, 211, 153);
        public static readonly Color Red         = Color.FromArgb(239, 68, 68);
        public static readonly Color RedHover    = Color.FromArgb(248, 113, 113);

        public static readonly Color[] ChartColors = {
            Color.FromArgb(99, 102, 241),
            Color.FromArgb(16, 185, 129),
            Color.FromArgb(245, 158, 11),
            Color.FromArgb(239, 68, 68),
            Color.FromArgb(14, 165, 233),
            Color.FromArgb(249, 115, 22),
            Color.FromArgb(236, 72, 153),
            Color.FromArgb(20, 184, 166),
        };
        public static readonly Font FontLarge  = new Font("Segoe UI", 22f, FontStyle.Bold);
        public static readonly Font FontTitle  = new Font("Segoe UI", 16f, FontStyle.Bold);
        public static readonly Font FontHead   = new Font("Segoe UI", 13f, FontStyle.Bold);
        public static readonly Font FontSub    = new Font("Segoe UI", 10f, FontStyle.Italic);
        public static readonly Font FontBody   = new Font("Segoe UI", 10f, FontStyle.Regular);
        public static readonly Font FontBold   = new Font("Segoe UI", 10f, FontStyle.Bold);
        public static readonly Font FontInput  = new Font("Segoe UI", 11f, FontStyle.Regular);
        public static readonly Font FontButton = new Font("Segoe UI", 10f, FontStyle.Bold);
        public static readonly Font FontSmall  = new Font("Segoe UI", 9f,  FontStyle.Regular);
        public static readonly Font FontBigNum = new Font("Segoe UI", 18f, FontStyle.Bold);

        public static void ApplyForm(Form f)
        {
            f.BackColor = Background;
            f.ForeColor = TextPrimary;
            f.Font = FontBody;
        }

        public static void ApplyPrimary(Button b)
        {
            b.BackColor = Accent;
            b.ForeColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = AccentHover;
            b.FlatAppearance.MouseDownBackColor = AccentDark;
            b.Font = FontButton;
            b.Cursor = Cursors.Hand;
        }

        public static void ApplySuccess(Button b)
        {
            b.BackColor = Green;
            b.ForeColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = GreenHover;
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(5, 150, 105);
            b.Font = FontButton;
            b.Cursor = Cursors.Hand;
        }

        public static void ApplyDanger(Button b)
        {
            b.BackColor = Red;
            b.ForeColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = RedHover;
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(220, 38, 38);
            b.Font = FontButton;
            b.Cursor = Cursors.Hand;
        }

        public static void ApplySecondary(Button b)
        {
            b.BackColor = Card;
            b.ForeColor = TextSub;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderColor = Border;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.MouseOverBackColor = CardHover;
            b.FlatAppearance.MouseDownBackColor = Card;
            b.Font = FontButton;
            b.Cursor = Cursors.Hand;
        }

        public static void ApplyInput(TextBox t)
        {
            t.BackColor = InputBg;
            t.ForeColor = TextPrimary;
            t.BorderStyle = BorderStyle.FixedSingle;
            t.Font = FontInput;
        }

        public static void ApplyCombo(ComboBox c)
        {
            c.BackColor = InputBg;
            c.ForeColor = TextPrimary;
            c.FlatStyle = FlatStyle.Flat;
            c.Font = FontInput;
            c.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static void ApplyListBox(ListBox l)
        {
            l.BackColor = InputBg;
            l.ForeColor = TextPrimary;
            l.BorderStyle = BorderStyle.None;
            l.Font = FontBody;
        }

        public static void ApplyDGV(DataGridView g)
        {
            g.BackgroundColor = Surface;
            g.GridColor = Border;
            g.BorderStyle = BorderStyle.None;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.RowHeadersVisible = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.DefaultCellStyle.BackColor = Surface;
            g.DefaultCellStyle.ForeColor = TextPrimary;
            g.DefaultCellStyle.SelectionBackColor = Accent;
            g.DefaultCellStyle.SelectionForeColor = Color.White;
            g.DefaultCellStyle.Font = FontBody;
            g.DefaultCellStyle.Padding = new Padding(6, 8, 6, 8);
            g.AlternatingRowsDefaultCellStyle.BackColor = Card;
            g.AlternatingRowsDefaultCellStyle.ForeColor = TextPrimary;
            g.ColumnHeadersDefaultCellStyle.BackColor = Card;
            g.ColumnHeadersDefaultCellStyle.ForeColor = TextSub;
            g.ColumnHeadersDefaultCellStyle.Font = FontBold;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Card;
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 8, 6, 8);
            g.ColumnHeadersHeight = 44;
            g.RowTemplate.Height = 36;
        }

        public static void ApplyMenuStrip(MenuStrip m)
        {
            m.BackColor = Surface;
            m.ForeColor = TextPrimary;
            m.Font = FontBody;
            m.Renderer = new ToolStripProfessionalRenderer(new DynamicColorTable());
            foreach (ToolStripItem item in m.Items)
                if (item is ToolStripMenuItem mi)
                    StyleMenuItem(mi);
        }

        private static void StyleMenuItem(ToolStripMenuItem item)
        {
            item.BackColor = Surface;
            item.ForeColor = TextPrimary;
            foreach (ToolStripItem sub in item.DropDownItems)
                if (sub is ToolStripMenuItem s)
                    StyleMenuItem(s);
        }
    }

    public class DynamicColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected              => AppTheme.CardHover;
        public override Color MenuItemSelectedGradientBegin => AppTheme.CardHover;
        public override Color MenuItemSelectedGradientEnd   => AppTheme.CardHover;
        public override Color MenuItemPressedGradientBegin  => AppTheme.Accent;
        public override Color MenuItemPressedGradientEnd    => AppTheme.Accent;
        public override Color MenuItemBorder                => AppTheme.Border;
        public override Color MenuBorder                    => AppTheme.Border;
        public override Color ToolStripDropDownBackground   => AppTheme.Surface;
        public override Color ImageMarginGradientBegin      => AppTheme.Surface;
        public override Color ImageMarginGradientMiddle     => AppTheme.Surface;
        public override Color ImageMarginGradientEnd        => AppTheme.Surface;
        public override Color SeparatorDark                 => AppTheme.Border;
        public override Color SeparatorLight                => AppTheme.Border;
    }
}



