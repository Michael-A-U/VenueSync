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
- Day 1: Installed Oracle 23ai Free, SQL Server Express, SSRS, SSDT, Python, Git, WAVE, Azure AD tenant.
