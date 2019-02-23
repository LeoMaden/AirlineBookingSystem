CREATE TABLE [dbo].[Bookings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BookingReference] NCHAR(10) NOT NULL, 
    [UserId] INT NOT NULL, 
    [OutFlight] INT NOT NULL, 
    [InFlight] INT NULL, 
    [NumberAdults] INT NOT NULL, 
    [NumberChildren] INT NOT NULL, 
    [TravelClass] NVARCHAR(50) NOT NULL, 
    [Last4CardDigits] NCHAR(4) NOT NULL, 
    [CardType] NVARCHAR(50) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [DateTimeCreated] DATETIME NOT NULL, 
    CONSTRAINT [FK_Bookings_Users] FOREIGN KEY (UserId) REFERENCES Users(Id), 
    CONSTRAINT [FK_Bookings_OutFlight] FOREIGN KEY (OutFlight) REFERENCES Flights(Id),
    CONSTRAINT [FK_Bookings_InFlight] FOREIGN KEY (InFlight) REFERENCES Flights(Id)
)
