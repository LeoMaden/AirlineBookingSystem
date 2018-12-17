CREATE TABLE [dbo].[FlightSchedules]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RouteCode] NVARCHAR(20) NOT NULL, 
    [OriginAirportId] INT NOT NULL, 
    [DestinationAirportId] INT NOT NULL, 
    [DepartureTime] TIME NOT NULL, 
    [ArrivalTime] TIME NOT NULL, 
    [DayOfWeek] NVARCHAR(15) NOT NULL, 
    CONSTRAINT [FK_FlightSchedules_OriginAirport] FOREIGN KEY (OriginAirportId) REFERENCES Airports(Id), 
    CONSTRAINT [FK_FlightSchedules_DestinationAirport] FOREIGN KEY (DestinationAirportId) REFERENCES Airports(Id)
)
