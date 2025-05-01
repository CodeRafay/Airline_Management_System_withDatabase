
```markdown
# ✈️ Airline Management System

A comprehensive **Airline Management System** built using **C# Windows Forms** and connected to an **Oracle Database**. This project enables role-based management of core airline operations, such as flight scheduling, employee management, ticket booking, task assignments, and revenue tracking.

---

## 📌 Features

### 🔐 Authentication
- **Sign Up / Sign In** functionality for:
  - Admin
  - Employee
  - Passenger
- Secure password handling and CNIC/email/phone format validations.

### 👨‍✈️ Admin Dashboard
- **Employee Management**: Add, update, search employees.
- **Flight Management**: Create, update, view flights using aircraft IDs.
- **Task Assignment**: Assign employees to specific flights with task details.
- **Revenue Reporting**: Generate revenue tables and export them as PDF using iTextSharp.
- **View Feedback** from passengers.

### 👷 Employee Dashboard
- View and manage personal profile.
- Sell tickets and manage bookings.
- Search passengers and flight assignments.

### 🧳 Passenger Panel
- View flight schedules.
- Book/cancel tickets.
- Provide feedback and rate services.

---

## 🛠️ Tech Stack

| Layer         | Technology                        |
|---------------|------------------------------------|
| Frontend      | Windows Forms (C#)                |
| Backend       | C# (.NET Framework)               |
| Database      | Oracle 11g/12c                    |
| ORM/Provider  | Oracle.ManagedDataAccess (ODP.NET)|
| Reporting     | iTextSharp for PDF Export         |

---

## ⚙️ Setup Instructions

### 🔧 Prerequisites

1. **.NET Framework 4.7+**
2. **Oracle Database (preferably 11g or 12c)**
3. **Oracle.ManagedDataAccess.Client** NuGet package
4. **iTextSharp** NuGet package
5. **Visual Studio 2019/2022**
6. Optional: Oracle SQL Developer for DB setup

### 🏗️ Installation Steps

1. **Clone this repository**
   ```bash
   git clone https://github.com/CodeRafay/airline-management-system.git
   cd airline-management-system
   ```

2. **Open the solution (`.sln`) file in Visual Studio**

3. **Install Dependencies**
   - Right-click on the solution > Manage NuGet Packages.
   - Install:
     - `Oracle.ManagedDataAccess`
     - `iTextSharp`

4. **Configure the Database**
   - Create a user/schema in Oracle DB (e.g., `AIRLINE`) with relevant tables and sample data.
   - Update the connection string in `SignIn.cs`:
     ```csharp
     string conStr = @"User Id=AIRLINE;Password=db_on_air;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=your-host-ip)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));";
     ```

5. **Build and Run**
   - Press `F5` or click "Start" in Visual Studio.

---

## 📄 Database Schema (High-Level Overview)

- **PASSENGER (USERID, CNIC, NAME, PHONE_NO, PASSWORD, EMAIL)**
- **EMPLOYEE (USERID, CNIC, NAME, PHONE_NO, PASSWORD, EMAIL)**
- **ADMIN (USERID, PASSWORD, EMAIL, CNIC, etc.)**
- **FLIGHT (FLIGHT_ID, DESTINATION, DEPARTURE_LOCATION, TIMES, STATUS, AIRCRAFT_ID, AV_SEATS)**
- **AIRCRAFT (AIRCRAFT_ID, SEATS, etc.)**
- **BOOKING, TASK, REVENUE, FEEDBACK** tables

(Refer to scripts folder or `DB_Schema.sql` if included)

---

## 📦 Output Sample

- **Admin Panel:** Add/update flights and generate PDF reports of revenue.
- **Employee Panel:** Real-time ticket sales and passenger lookup.
- **Passenger Panel:** Interactive booking and feedback system.

---

## 📚 Future Enhancements

- Email notifications for booking confirmations.
- Role-based access using encryption libraries.
- Integration with flight APIs for live status updates.
- Enhanced UI/UX using WPF or Web-based migration (ASP.NET Core).

---

## 🙌 Contributors
- Rafay Adeel 
- Muhammad Muzammil Noor 


