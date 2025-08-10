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

## Database Schemas
- SQL Server: Venues (ID, Name, Location), Headcounts (ID, VenueID, Count, Timestamp).
- Oracle: Similar tables for legacy sync.

## Progress
- **Initial Setup (August 10, 2025)**:
  - Installed Oracle Database 23ai Free, SQL Server Express with SSRS and SSDT, Python, GitHub Desktop, and WAVE Chrome extension. Configured Azure AD tenant (`VenueSyncOrg.onmicrosoft.com`) for authentication.
  - Established a public GitHub repository (`VenueSync`) for transparent version control and collaboration.
  - Configured `.gitignore` (Visual Studio template, extended for Python `__pycache__`, `appsettings.json`, and database files) to exclude sensitive data and build artifacts, ensuring security.
  - Updated `.gitignore` to include ASP.NET Core configs (`appsettings.json`, `appsettings.*.json`), Oracle files (`*.dbf`), Azure deployment settings (`.azure/`), and Python virtual environments (`env/`, `venv/`) for comprehensive exclusion of sensitive and temporary files.