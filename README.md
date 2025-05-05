# 📅 Terminarz(Scheduler) – Weekly Event Planner Application

**Terminarz(Scheduler)** is a desktop application built with WPF, designed to help users plan and view events in a weekly calendar view. Events are stored in a local **SQL Server** database and displayed in a calendar grid with assigned colors, names, dates, and times.

---

##  Technologies and Tools

- **.NET Framework / .NET Core (WPF)**
- **C#**
- **Entity Framework 6**
- **SQL Server LocalDB** – used as the local database
- **MVVM (Model-View-ViewModel)** – application architecture
- **MahApps.Metro** – for modern UI components

---

## Features

- Weekly calendar grid (days as columns, hours as rows)
- Add new events (with name, date, time, location, color, and description)
- Automatically position events in the correct day/time slot
- Color-coded events based on user selection
- Navigate between weeks using arrow buttons
- Delete events
- Events are loaded from a SQL Server (LocalDB) database

---

## Screenshots

![image](https://github.com/user-attachments/assets/29fdfb68-171e-4b6b-a162-66c4b6947a30)
<br>
<i>Main view</i>
<br>


![image](https://github.com/user-attachments/assets/96e40c82-ca81-4650-8098-dda7e7de58e0)
<br>
<i>Add event</i>

---

## System Requirements

- Operating System: **Windows 10 / 11**
- .NET Framework: **>= 4.7.2** or **.NET 6+**
- SQL Server LocalDB (comes with Visual Studio)
- Visual Studio 2022 or newer with **.NET Desktop Development** workload

---

## Installation & Run Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/Terminarz.git
