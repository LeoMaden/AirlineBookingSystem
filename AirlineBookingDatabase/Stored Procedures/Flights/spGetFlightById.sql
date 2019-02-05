--
-- Get details of a flight using its
-- unique Id.
--
CREATE PROCEDURE [dbo].[spGetFlightById]
	@Id int
AS
	Select * From Flights
	Where Id = @Id;
RETURN 0
