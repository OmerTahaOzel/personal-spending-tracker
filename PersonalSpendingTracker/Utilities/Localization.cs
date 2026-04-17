using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PersonalSpendingTracker.Utilities
{
    public static class Localization
    {
        public static event Action LanguageChanged;
        
        private static string _currentLang = "en"; // "en" or "tr"
        public static string CurrentLang
        {
            get => _currentLang;
            set
            {
                if (_currentLang != value)
                {
                    _currentLang = value;
                    SaveLanguage();
                    LanguageChanged?.Invoke();
                }
            }
        }

        private static string LangFile => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
            "KisIselHarcamaTakip", "lang.txt");

        public static void LoadLanguage()
        {
            try
            {
                if (File.Exists(LangFile))
                {
                    var saved = File.ReadAllText(LangFile).Trim().ToLower();
                    if (saved == "tr" || saved == "en") _currentLang = saved;
                }
            }
            catch { }
        }

        private static void SaveLanguage()
        {
            try
            {
                var dir = Path.GetDirectoryName(LangFile);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                File.WriteAllText(LangFile, _currentLang);
            }
            catch { }
        }

        public static void ToggleLanguage()
        {
            CurrentLang = CurrentLang == "en" ? "tr" : "en";
        }
        private static readonly Dictionary<string, Dictionary<string, string>> Strings = new()
        {
            { "Warning", new() { { "en", "Warning" }, { "tr", "Uyarı" } } },
            { "Success", new() { { "en", "Success" }, { "tr", "Başarılı" } } },
            { "Error", new() { { "en", "Error" }, { "tr", "Hata" } } },
            { "Info", new() { { "en", "Information" }, { "tr", "Bilgi" } } },
            { "Confirm", new() { { "en", "Confirm" }, { "tr", "Onay" } } },
            { "MainForm_Title", new() { { "en", "Personal Spending Tracker" }, { "tr", "Kişisel Harcama Takip" } } },
            { "LoginForm_Title", new() { { "en", "Expense Tracker" }, { "tr", "Harcama Takip" } } },
            { "LoginForm_lblTitle", new() { { "en", "Expense Tracker" }, { "tr", "Harcama Takip" } } },
            { "LoginForm_lblSub", new() { { "en", "Personal Finance Management" }, { "tr", "Kişisel Finans Yönetimi" } } },
            
            { "RegisterForm_Title", new() { { "en", "Register" }, { "tr", "Kayıt Ol" } } },
            { "RegisterForm_lblTitle", new() { { "en", "Create Account" }, { "tr", "Hesap Oluştur" } } },
            { "RegisterForm_lblSub", new() { { "en", "Join the Expense Tracker" }, { "tr", "Harcama Takibine Katıl" } } },
            
            { "CategoryForm_Title", new() { { "en", "Categories" }, { "tr", "Kategoriler" } } },
            { "CategoryForm_lblTitle", new() { { "en", "Category Management" }, { "tr", "Kategori Yönetimi" } } },

            { "AddExpenseForm_Title", new() { { "en", "Add Expense" }, { "tr", "Harcama Ekle" } } },
            { "AddExpenseForm_lblTitle", new() { { "en", "New Expense" }, { "tr", "Yeni Harcama" } } },

            { "ReportForm_Title", new() { { "en", "Reports" }, { "tr", "Raporlar" } } },
            { "ReportForm_lblTitle", new() { { "en", "Expense Reports" }, { "tr", "Harcama Raporları" } } },

            { "lblUser", new() { { "en", "Username" }, { "tr", "Kullanıcı Adı" } } },
            { "lblPass", new() { { "en", "Password" }, { "tr", "Şifre" } } },
            { "btnLogin", new() { { "en", "Login" }, { "tr", "Giriş Yap" } } },
            { "btnRegister", new() { { "en", "Don't have an account? Register" }, { "tr", "Hesabınız yok mu? Kayıt Ol" } } },
            { "Login_BackBtn", new() { { "en", "Back to Login" }, { "tr", "Girişe Dön" } } },
            { "Err_EmptyFields", new() { { "en", "Username and password cannot be empty." }, { "tr", "Kullanıcı adı ve şifre boş bırakılamaz." } } },
            { "Err_UserExists", new() { { "en", "This username is already taken." }, { "tr", "Bu kullanıcı adı zaten alınmış." } } },
            { "Msg_RegSuccess", new() { { "en", "Registration successful! You can now login." }, { "tr", "Kayıt başarılı! Giriş yapabilirsiniz." } } },
            { "Err_InvalidCreds", new() { { "en", "Invalid username or password." }, { "tr", "Kullanıcı adı veya şifre hatalı." } } },
            { "lblTotalCaption", new() { { "en", "Total Current Expenses" }, { "tr", "Güncel Toplam Harcama" } } },
            { "btnKapat", new() { { "en", "Close" }, { "tr", "Kapat" } } },
            { "btnLang", new() { { "en", "Language: EN \U0001F1FA\U0001F1F8" }, { "tr", "Dil: TR \U0001F1F9\U0001F1F7" } } },
            { "ThemeAuto", new() { { "en", "Theme: Auto" }, { "tr", "Tema: Otomatik" } } },
            { "ThemeDark", new() { { "en", "Theme: Dark" }, { "tr", "Tema: Koyu" } } },
            { "ThemeLight", new() { { "en", "Theme: Light" }, { "tr", "Tema: Açık" } } },
            { "harcamaEkleToolStripMenuItem", new() { { "en", "Add Expense" }, { "tr", "Harcama Ekle" } } },
            { "silToolStripMenuItem", new() { { "en", "Delete" }, { "tr", "Sil" } } },
            { "kategorilerToolStripMenuItem", new() { { "en", "Categories" }, { "tr", "Kategoriler" } } },
            { "raporlarToolStripMenuItem", new() { { "en", "Reports" }, { "tr", "Raporlar" } } },
            { "csvAktarToolStripMenuItem", new() { { "en", "Export CSV" }, { "tr", "Dışa Aktar (CSV)" } } },
            { "logoutToolStripMenuItem", new() { { "en", "Logout" }, { "tr", "Çıkış Yap" } } },
            { "Col_Category", new() { { "en", "Category" }, { "tr", "Kategori" } } },
            { "Col_Amount", new() { { "en", "Amount" }, { "tr", "Tutar" } } },
            { "Col_Date", new() { { "en", "Date" }, { "tr", "Tarih" } } },
            { "Err_DelSelectHarcama", new() { { "en", "Select an expense from the list to delete." }, { "tr", "Silmek için listeden bir harcama seçiniz." } } },
            { "Msg_DelConfirmHarcama", new() { { "en", "Delete expense for '{0}' — {1}?" }, { "tr", "'{0}' — {1} harcaması silinsin mi?" } } },
            { "Msg_CreatedCsv", new() { { "en", "File created successfully." }, { "tr", "Dosya başarıyla oluşturuldu." } } },
            { "lblCatName", new() { { "en", "Category Name:" }, { "tr", "Kategori Adı:" } } },
            { "lblListHead", new() { { "en", "Existing Categories" }, { "tr", "Mevcut Kategoriler" } } },
            { "lblAddHead", new() { { "en", "Add New Category" }, { "tr", "Yeni Kategori Ekle" } } },
            { "btnAdd", new() { { "en", "Add" }, { "tr", "Ekle" } } },
            { "btnDelete", new() { { "en", "Delete" }, { "tr", "Sil" } } },
            { "Err_CatEmpty", new() { { "en", "Category name cannot be empty." }, { "tr", "Kategori adı boş bırakılamaz." } } },
            { "Err_CatExists", new() { { "en", "This category already exists." }, { "tr", "Bu kategori zaten mevcut." } } },
            { "Err_DelSelectCat", new() { { "en", "Select a category to delete." }, { "tr", "Silmek için listeden bir kategori seçiniz." } } },
            { "Msg_DelConfirmCat", new() { { "en", "'{0}' will be deleted. Proceed?" }, { "tr", "'{0}' silinecek. Onaylıyor musunuz?" } } },
            { "lblCat", new() { { "en", "Category" }, { "tr", "Kategori" } } },
            { "lblAmount", new() { { "en", "Amount (TRY)" }, { "tr", "Tutar (TL)" } } },
            { "lblDate", new() { { "en", "Date" }, { "tr", "Tarih" } } },
            { "btnSave", new() { { "en", "Save Expense" }, { "tr", "Harcamayı Kaydet" } } },
            { "Err_SelectCat", new() { { "en", "Please select a category." }, { "tr", "Lütfen bir kategori seçiniz." } } },
            { "Err_InvalidAmount", new() { { "en", "Please enter a valid positive amount." }, { "tr", "Lütfen geçerli ve pozitif bir tutar giriniz." } } },
            { "lblFilterCat", new() { { "en", "Category Filter" }, { "tr", "Kategori Filtresi" } } },
            { "btnBar", new() { { "en", "Bar Chart" }, { "tr", "Çubuk Grafik" } } },
            { "btnPie", new() { { "en", "Pie Chart" }, { "tr", "Pasta Grafik" } } },
            { "chkDateFilter", new() { { "en", "Enable Date Filter" }, { "tr", "Tarih Filtresini Etkinleştir" } } },
            { "btnApply", new() { { "en", "Apply Filters" }, { "tr", "Filtreleri Uygula" } } },
            { "lblStatTotal", new() { { "en", "Total Current Match:" }, { "tr", "Filtre Toplamı:" } } },
            { "lblStatTop", new() { { "en", "Top Category:" }, { "tr", "En Çok Harcanan:" } } },
            { "lblStatCount", new() { { "en", "Item Count:" }, { "tr", "Kayıt Sayısı:" } } },
            { "AllCategories", new() { { "en", "-- All Categories --" }, { "tr", "-- Tüm Kategoriler --" } } },
        };

        public static string Get(string key)
        {
            if (Strings.ContainsKey(key) && Strings[key].ContainsKey(_currentLang))
                return Strings[key][_currentLang];
            return key; // fallback to key identifier if not found
        }

        public static void ApplyToForm(Form form)
        {
            string fKey = form.Name + "_Title";
            if (Strings.ContainsKey(fKey)) form.Text = Get(fKey);

            ApplyToControls(form.Controls, form.Name);
        }

        private static void ApplyToControls(Control.ControlCollection controls, string formName)
        {
            foreach (Control c in controls)
            {
                string specificKey = formName + "_" + c.Name;
                if (Strings.ContainsKey(specificKey)) c.Text = Get(specificKey);
                else if (Strings.ContainsKey(c.Name)) c.Text = Get(c.Name);
                
                if (c is MenuStrip ms)
                {
                    foreach (ToolStripItem item in ms.Items)
                        ApplyToToolStripItem(item, formName);
                }

                if (c.HasChildren) ApplyToControls(c.Controls, formName);
            }
        }

        private static void ApplyToToolStripItem(ToolStripItem item, string formName)
        {
            string specificKey = formName + "_" + item.Name;
            if (Strings.ContainsKey(specificKey)) item.Text = Get(specificKey);
            else if (Strings.ContainsKey(item.Name)) item.Text = Get(item.Name);

            if (item is ToolStripMenuItem tsmi && tsmi.HasDropDownItems)
            {
                foreach (ToolStripItem sub in tsmi.DropDownItems)
                    ApplyToToolStripItem(sub, formName);
            }
        }
    }
}


