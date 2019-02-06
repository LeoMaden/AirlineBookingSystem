--
-- Insert a new flight into the database.
--
-- The auto-generated Id of the user is assigned
-- to an output parameter
--
CREATE PROCEDURE [dbo].[spInsertFlight]
    @FlightScheduleId int,
	@OriginAirport int,
	@DestinationAirport int,
	@DepartureDateTime datetime,
	@ArrivalDateTime datetime,
	@Id int = 0 out
AS
	Insert into Flights(FlightScheduleId,
						[OriginAirportId],
						[DestinationAirportId],
						DepartureDateTime,
						ArrivalDateTime)
	values(@FlightScheduleId, 
		   @OriginAirport, 
		   @DestinationAirport, 
		   @DepartureDateTime, 
		   @ArrivalDateTime);
	
	-- Set @Id to the Id of the record just inserted.
	select @Id = SCOPE_IDENTITY();
RETURN 0
