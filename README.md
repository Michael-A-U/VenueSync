# VenueSync: Real-Time Headcount Reporting System

## Project Overview

VenueSync is a web application for Hertfordshire County Council venues (e.g., libraries, community centers) to track headcounts in real time. Doormen submit headcounts via a mobile-friendly form, stored in SQL Server, with plans for Oracle syncing, SSRS reports, Azure AD authentication, and WCAG 2.1 compliance. Built for the Senior Application Engineer role.

---

## Requirements

### Functional

- Mobile-friendly form for doormen to submit headcounts.
- Dashboard for admins to view headcount reports (in progress).
- SSRS reports for detailed analytics (planned).

### Technical

- ASP.NET Core MVC (.NET 8.0), Entity Framework Core.
- SQL Server Express (VenueSyncDB), Oracle 23ai Free (future).
- Azure Active Directory for authentication.
- Bootstrap for responsive UI, WCAG 2.1 compliance.
- Python/PowerShell for scripting (future).
- Git/GitHub for version control.

### Non-Functional

- Secure (AAD, GDPR-compliant).
- Maintainable code and documentation.
- Accessible (WCAG 2.1).

---

## ALM Phases

- **Requirements:** Defined in this README, focusing on doorman workflow and reporting needs.
- **Design:** Database schemas in `/Database`, ERD in `/Database/VenueSyncERD.png`.
- **Development:** ASP.NET Core app with headcount form, partial AAD integration.
- **Testing:** Database queries, WAVE for accessibility (planned).
- **Deployment:** Local development, Azure planned.
- **Maintenance:** Backup scripts in `/Database` (planned).

---

## Workflow

Doormen log in to the VenueSync web app on smartphones using Azure AD credentials (e.g., `michael@BIwithMichaeloutlook.onmicrosoft.com`). After authentication, they access a mobile-friendly form at `/Headcount/Create`, select a venue (e.g., "Central Library") from a dropdown, enter a headcount (e.g., 30) and optional notes (e.g., "Morning shift"), and submit. The app validates input, saves the headcount with a timestamp to SQL Server, and displays a success message. Admins will view aggregated data via a dashboard (in progress).

---

## Database Schemas

### SQL Server (VenueSyncDB):

#### Users: Stores authenticated users for AAD integration and auditing.

- `UserID` (Primary Key, INT, auto-increment)  
- `Username` (NVARCHAR(50), unique, required, e.g., `michael@BIwithMichaeloutlook.onmicrosoft.com`)  
- `Role` (NVARCHAR(50), required, e.g., "Doorman", "Admin")  

#### Venues: Stores council venues for headcount tracking.

- `VenueID` (Primary Key, INT, auto-increment)  
- `VenueName` (NVARCHAR(100), unique, required, e.g., "Central Library")  
- `Location` (NVARCHAR(200), required, e.g., "Stevenage")  
- `VenueType` (NVARCHAR(50), required, e.g., "Library")  

#### Headcounts: Stores headcount submissions.

- `HeadcountID` (Primary Key, INT, auto-increment)  
- `VenueID` (Foreign Key to Venues.VenueID, INT, required)  
- `UserID` (Foreign Key to Users.UserID, INT, required)  
- `Count` (INT, required, non-negative)  
- `Timestamp` (DATETIME, required, defaults to current time)  
- `Notes` (NVARCHAR(500), optional, e.g., "Evening event")  

---

### Relationships

- One-to-Many: Users to Headcounts (a user submits multiple headcounts).
- One-to-Many: Venues to Headcounts (a venue has multiple headcounts).
- Constraints: Foreign keys ensure referential integrity; `Count >= 0` prevents invalid submissions.

---

## Progress

### Initial Setup (August 10-11, 2025):

- Installed Oracle Database 23ai Free, SQL Server Express with SSRS and SSDT, Python, GitHub Desktop, and WAVE Chrome extension.
- Configured Azure AD tenant (`BIwithMichaeloutlook.onmicrosoft.com`) for authentication.
- Created public GitHub repository (`https://github.com/YourUsername/VenueSync`) for version control.
- Set up `.gitignore` for Visual Studio, Python `__pycache__`, `appsettings.json`, Oracle files (`*.dbf`), Azure settings (`.azure/`), and virtual environments (`env/`, `venv/`).
- Designed SQL Server schema (`Users`, `Venues`, `Headcounts`) in `/Database/sqlserver_schema.sql`.
- Generated ERD (`/Database/VenueSyncERD.png`) to visualize table relationships.

### Development (August 12-13, 2025):

- Built ASP.NET Core MVC app (`VenueSyncWeb`) with .NET 8.0.
- Installed NuGet packages: `Microsoft.EntityFrameworkCore.SqlServer (8.0.8)`, `Microsoft.EntityFrameworkCore.Design (8.0.8)`, `Microsoft.Identity.Web (3.3.0)`.
- Configured `appsettings.json` and `Program.cs` for SQL Server (EVENYOUBRUTUS) and AAD authentication.
- Added `HeadcountController` and `Views\Headcount\Create.cshtml` for mobile-friendly form with venue dropdown, headcount input, and notes.
- Fixed NuGet package issues and resolved F5 key conflict (used Fn + F5).
- Added `VenueType` column to Venues table for categorization (e.g., Library, Community Center).
- Populated database with 12 venues (across Stevenage, Hertford, Watford, etc.), 4 users, and 18 headcounts for testing.
- Fixed foreign key errors (`FK__Headcount__Venue__3F466844`) and IDENTITY_INSERT issues for Users and Venues.
- Updated `Venue.cs` and `HeadcountController.cs` to support `VenueType`.

---

## Notes

- Replace `YourUsername` with your GitHub username.
- `appsettings.json` is in `.gitignore` for security (contains `ClientSecret`).
- AAD integration is configured but not fully implemented (uses mock `UserID=1`).
- Run `FixVenueSyncDB.sql` to populate database for testing.
- Next: Implement `DashboardController` for reporting.
