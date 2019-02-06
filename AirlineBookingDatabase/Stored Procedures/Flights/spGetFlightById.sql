--
-- Get details of a flight using its
-- unique Id.
--
CREATE PROCEDURE [dbo].[spGetFlightById]
	@Id int
AS
	-- Select the flight details, joining the airport table on the origin and destination airport id columns.
	Select f.*, origin.Id OriginId, origin.*, destination.Id DestinationId, destination.* 
	From Flights f
	join Airports origin on f.[OriginAirportId] = origin.Id
	join Airports destination on f.[DestinationAirportId] = destination.Id
	Where f.Id = @Id;

	-- Select the id of the flight schedule.
	select FlightScheduleId 
	from Flights
	where Flights.Id = @Id;
RETURN 0
