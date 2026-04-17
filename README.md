# Personal Spending Tracker

A lightweight desktop application for tracking personal expenses, built with **.NET 8** and **Windows Forms**.

---

## Features

| Feature | Description |
|---|---|
| **User Accounts** | Multi-user support with login and registration |
| **Add Expenses** | Log expenses with category, amount (TRY), and date |
| **Delete Expenses** | Remove entries with a confirmation dialog |
| **Category Management** | Create and delete custom spending categories |
| **Reports and Charts** | Bar and pie charts with date and category filters |
| **CSV Export** | Export expense records to a `.csv` file |
| **Light / Dark / Auto Theme** | Dynamic theme switching at runtime |
| **Bilingual UI** | Full English and Turkish language support |
| **Local Database** | SQLite database stored in `AppData` — no installation required |

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (Windows)
- Windows 10 or later

### Run from Source

```bash
git clone https://github.com/OmerTahaOzel/personal-spending-tracker.git
cd personal-spending-tracker
dotnet run --project PersonalSpendingTracker/PersonalSpendingTracker.csproj
```

### Publish as Single Executable

```bash
dotnet publish PersonalSpendingTracker/PersonalSpendingTracker.csproj ^
  -c Release ^
  -r win-x64 ^
  --self-contained true ^
  -p:PublishSingleFile=true ^
  -o ./publish
```

The output `PersonalSpendingTracker.exe` in `./publish` can be distributed and executed on any Windows machine without a .NET installation.

---

## Project Structure

```
personal-spending-tracker/
├── PersonalSpendingTracker/
│   ├── Infrastructure/
│   │   └── Database/
│   │       └── DbHelper.cs          # SQLite connection and table initialization
│   ├── UI/
│   │   └── Forms/
│   │       ├── LoginForm.cs         # Login screen
│   │       ├── RegisterForm.cs      # User registration screen
│   │       ├── MainForm.cs          # Main dashboard and expense list
│   │       ├── AddExpenseForm.cs    # Add new expense dialog
│   │       ├── CategoryForm.cs      # Category management
│   │       └── ReportForm.cs        # Charts and filtered reports
│   ├── Utilities/
│   │   ├── AppTheme.cs              # Light / Dark / Auto theme engine
│   │   ├── CsvHelper.cs             # CSV export logic
│   │   └── Localization.cs          # English / Turkish language strings
│   └── Program.cs                   # Application entry point
└── PersonalSpendingTracker.sln
```

---

## Technology Stack

| Layer | Technology |
|---|---|
| Framework | .NET 8 — Windows Forms |
| Database | SQLite via `System.Data.SQLite.Core` |
| Charts | `HIC.System.Windows.Forms.DataVisualization` |
| Language | C# 12 |

---

## Data Storage

All data is stored locally. No network connection is required.

| File | Path |
|---|---|
| Database | `%AppData%\KisIselHarcamaTakip\database.db` |
| Language Preference | `%AppData%\KisIselHarcamaTakip\lang.txt` |

---

## Localization

The interface supports full language switching at runtime between **English** and **Turkish**. The selected language persists across sessions and can be toggled via the Language button on the main screen.

---

## Theming

Three theme modes are available and can be cycled via the Theme button:

- **Auto** — follows the Windows system color preference
- **Light** — white background with standard contrast
- **Dark** — dark background with high-contrast text

---

## License

This project is open source and available under the [MIT License](LICENSE).
