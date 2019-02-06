CREATE TABLE [dbo].[Flights]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FlightScheduleId] INT NULL, 
    [OriginAirportId] INT NOT NULL, 
    [DestinationAirportId] INT NOT NULL, 
    [DepartureDateTime] DATETIME NOT NULL, 
    [ArrivalDateTime] DATETIME NOT NULL, 
    CONSTRAINT [FK_Flights_FlightSchedules] FOREIGN KEY (FlightScheduleId) REFERENCES FlightSchedules(Id), 
    CONSTRAINT [FK_Flights_OriginAirport] FOREIGN KEY ([OriginAirportId]) REFERENCES Airports(Id),
    CONSTRAINT [FK_Flights_DestinationAirport] FOREIGN KEY ([DestinationAirportId]) REFERENCES Airports(Id)
)
