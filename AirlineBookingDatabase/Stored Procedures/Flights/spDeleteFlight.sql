--
-- Delete a flight from the database using 
-- its unique Id.
--
CREATE PROCEDURE [dbo].[spDeleteFlight]
	@Id int
AS
	Delete From Flights
	Where Id = @Id;
RETURN 0
