-- Airports --
-- Allow values to be inserted into identity column. --
SET IDENTITY_INSERT dbo.Airports ON;

insert into Airports(Id, AirportCode, FriendlyName)
values(1, 'JFK', 'John F. Kennedy'),
	  (2, 'LHR', 'London Heathrow'),
	  (3, 'CDG', 'Charles de Gaulle'),
	  (4, 'AMS', 'Amsterdam Schiphol'),
	  (5, 'FRA', 'Frankfurt am Main'),
	  (6, 'IST', 'Istanbul Atatürk'),
	  (7, 'MAD', 'Madrid–Barajas'),
	  (8, 'MUC', 'Munich'),
	  (9, 'LGW', 'London Gatwick'),
	  (10, 'ZRH', 'Zurich');
	  
-- Prevent values being inserted into identity column. --
SET IDENTITY_INSERT dbo.Airports OFF;


-- Flights --
SET IDENTITY_INSERT dbo.Flights ON;

insert into Flights(Id, OriginAirportId, DestinationAirportId, DepartureDateTime, ArrivalDateTime)
values(1, 1, 2, '2019-04-01 9:00', '2019-04-01 13:00'),
	  (2, 1, 2, '2019-04-01 17:00', '2019-04-02 01:00'),
	  (3, 2, 1, '2019-04-03 14:00', '2019-04-03 22:00'),
	  (4, 2, 1, '2019-04-03 23:00', '2019-04-04 7:00'),
	  (5, 2, 3, '2019-04-01 8:30', '2019-04-01 10:15'),
	  (6, 2, 4, '2019-04-01 9:30', '2019-04-01 12:35'),
	  (7, 2, 5, '2019-04-01 10:00', '2019-04-01 13:22');

SET IDENTITY_INSERT dbo.Flights OFF;
