# VenueSync: Real-Time Headcount Reporting System

## Project Overview
A web app for council venues (e.g., libraries, community centers) to input headcounts, stored in SQL Server, synced to Oracle, with SSRS reports, Azure AD authentication, and WCAG compliance. Built for Hertfordshire County Council Senior Application Engineer role.

## Requirements
- Functional: Mobile-friendly form, dashboard, SSRS reports.
- Technical: SQL Server Express, Oracle 23ai Free, Python/PowerShell, Azure AD, WCAG 2.1.
- Non-Functional: Secure, maintainable, GDPR-compliant.

## ALM Phases
1. Requirements: This README.
2. Design: Database schemas in /Database.
3. Development: ASP.NET Core app.
4. Testing: WAVE, DB queries.
5. Deployment: Local/Azure.
6. Maintenance: Backup scripts.

## Workflow
Doormen log in to the VenueSync web app on their smartphones using personal Azure AD credentials (e.g., `doorman1@VenueSyncOrg.onmicrosoft.com`). After authentication, they access a mobile-friendly form, select their assigned venue (e.g., "Community Center") from a dropdown, enter the current headcount (e.g., 75), add optional notes, and submit. The app validates the input, saves the data with an automatic timestamp, and confirms success, enabling quick, secure, and accessible data entry during busy shifts.

## Database Schemas
- **SQL Server**:
  - **Users**: Stores authenticated users (e.g., doormen, admins) for Azure AD integration and auditing.
    - UserID (Primary Key, INT, auto-increment)
    - Username (NVARCHAR(50), unique, required, e.g., `doorman1@VenueSyncOrg.onmicrosoft.com`)
    - Role (NVARCHAR(50), required, e.g., 'Doorman', 'Admin')
  - **Venues**: Stores council venues for headcount tracking.
    - VenueID (Primary Key, INT, auto-increment)
    - VenueName (NVARCHAR(100), unique, required, e.g., 'Central Library')
    - Location (NVARCHAR(200), required, e.g., 'Stevenage')
  - **Headcounts**: Stores headcount submissions with links to users and venues.
    - HeadcountID (Primary Key, INT, auto-increment)
    - VenueID (Foreign Key to Venues.VenueID, INT, required)
    - UserID (Foreign Key to Users.UserID, INT, required)
    - Count (INT, required, non-negative)
    - Timestamp (DATETIME, required, defaults to current time)
    - Notes (NVARCHAR(500), optional, e.g., 'Evening event')
  - **Relationships**:
    - One-to-Many: Users to Headcounts (a user submits multiple headcounts).
    - One-to-Many: Venues to Headcounts (a venue has multiple headcounts).
  - **Constraints**: Foreign keys ensure referential integrity; Count >= 0 prevents invalid submissions.

## Progress
- **Initial Setup (August 10, 2025)**:
  - Installed Oracle Database 23ai Free, SQL Server Express with SSRS and SSDT, Python, GitHub Desktop, and WAVE Chrome extension. Configured Azure AD tenant (`VenueSyncOrg.onmicrosoft.com`) for authentication.
  - Established a public GitHub repository (`VenueSync`) for transparent version control and collaboration.
  - Configured `.gitignore` (Visual Studio template, extended for Python `__pycache__`, `appsettings.json`, and database files) to exclude sensitive data and build artifacts, ensuring security.
  - Updated `.gitignore` to include ASP.NET Core configs (`appsettings.json`, `appsettings.*.json`), Oracle files (`*.dbf`), Azure deployment settings (`.azure/`), and Python virtual environments (`env/`, `venv/`) for comprehensive exclusion of sensitive and temporary files.
  - Designed and implemented SQL Server schema (`Users`, `Venues`, `Headcounts` tables) based on doorman workflow (individual Azure AD login, mobile headcount submission). Committed schema to repository under `Database/sqlserver_schema.sql`.
  - Added workflow summary to README to clarify doorman user flow, aligning schema with real-world use case.
  - Generated ERD for SQL Server schema, saved as `Database/VenueSyncERD.png` to visualize table relationships.