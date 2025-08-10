VenueSync: Real-Time Headcount Reporting System

Project Overview

A web app for council venues (e.g., libraries, community centers) to input headcounts, stored in SQL Server, synced to Oracle, with SSRS reports, Azure AD authentication, and WCAG compliance. Built for Hertfordshire County Council Senior Application Engineer role.

Requirements

Functional: Mobile-friendly form, dashboard, SSRS reports.

Technical: SQL Server Express, Oracle 23ai Free, Python/PowerShell, Azure AD, WCAG 2.1.

Non-Functional: Secure, maintainable, GDPR-compliant.

ALM Phases

Requirements: This README.
Design: Database schemas in /Database.
Development: ASP.NET Core app.
Testing: WAVE, DB queries.
Deployment: Local/Azure.
Maintenance: Backup scripts.
Database Schemas

SQL Server: Venues (ID, Name, Location), Headcounts (ID, VenueID, Count, Timestamp).

Oracle: Similar tables for legacy sync.

Progress

Day 1 (August 10, 2025):
Installed Oracle Database 23ai Free, SQL Server Express with SSRS and SSDT, Python, GitHub Desktop, WAVE Chrome extension, and created an Azure AD tenant (VenueSyncOrg.onmicrosoft.com) for secure authentication.
Created a public GitHub repository (VenueSync) to share the project transparently, demonstrating ALM.
Added a .gitignore file (Visual Studio template, customized for Python __pycache__, appsettings.json, and database files) to exclude sensitive data and build artifacts, ensuring cybersecurity.
