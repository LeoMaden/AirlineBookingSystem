--
-- Update the flight with the given Id to have 
-- fields that match the values given.
--
CREATE PROCEDURE [dbo].[spUpdateFlight]
	@Id int,
    @FlightScheduleId int,
	@OriginAirport int,
	@DestinationAirport int,
	@DepartureDateTime datetime,
	@ArrivalDateTime datetime
AS
	Update Flights
	Set FlightScheduleId = @FlightScheduleId,
		[OriginAirportId] = @OriginAirport,
		[DestinationAirportId] = @DestinationAirport,
		DepartureDateTime = @DepartureDateTime,
		ArrivalDateTime = @ArrivalDateTime
	Where Id = @Id;
RETURN 0
