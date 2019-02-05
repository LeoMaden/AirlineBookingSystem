--
-- Get the flights from the database that
-- are travelling between the specified airports
-- on the specified date
--
CREATE PROCEDURE [dbo].[spGetFlights]
	@OriginAirport int,
	@DestinationAirport int,
	@Date date
AS
	Select * From Flights
	Where CONVERT(Date, DepartureDateTime) = @Date
	and OriginAirport = @OriginAirport
	and DestinationAirport = @DestinationAirport;
RETURN 0
