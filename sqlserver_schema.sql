CREATE DATABASE VenueSyncDB;
GO
USE VenueSyncDB;
GO
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Role NVARCHAR(50) NOT NULL
);
CREATE TABLE Venues (
    VenueID INT PRIMARY KEY IDENTITY(1,1),
    VenueName NVARCHAR(100) UNIQUE NOT NULL,
    Location NVARCHAR(200) NOT NULL
);
CREATE TABLE Headcounts (
    HeadcountID INT PRIMARY KEY IDENTITY(1,1),
    VenueID INT NOT NULL,
    UserID INT NOT NULL,
    Count INT NOT NULL CHECK (Count >= 0),
    Timestamp DATETIME DEFAULT GETDATE() NOT NULL,
    Notes NVARCHAR(500) NULL,
    FOREIGN KEY (VenueID) REFERENCES Venues(VenueID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
-- Sample Data
INSERT INTO Users (Username, Role) VALUES ('doorman1@VenueSyncOrg.onmicrosoft.com', 'Doorman');
INSERT INTO Users (Username, Role) VALUES ('admin1@VenueSyncOrg.onmicrosoft.com', 'Admin');
INSERT INTO Venues (VenueName, Location) VALUES ('Central Library', 'Stevenage');
INSERT INTO Venues (VenueName, Location) VALUES ('Community Center', 'Hertford');
INSERT INTO Headcounts (VenueID, UserID, Count, Notes) VALUES (1, 1, 50, 'Evening event');
INSERT INTO Headcounts (VenueID, UserID, Count) VALUES (2, 1, 30);
GO