CREATE DATABASE DataBaseQuizGame
GO
USE DataBaseQuizGame
GO
CREATE TABLE Room (
    RoomID INT PRIMARY KEY,
    RoomStatus NVARCHAR(50)
);
GO
CREATE TABLE Player (
    PlayerIP NVARCHAR( 15) PRIMARY KEY,
    RoomID INT FOREIGN KEY REFERENCES Room(RoomID),
    PlayerName NVARCHAR(100),
    PlayerStatus NVARCHAR(50),
    Score INT,
	Corr_Num INT,
    Stack INT,
    Timestamps INT
);
GO