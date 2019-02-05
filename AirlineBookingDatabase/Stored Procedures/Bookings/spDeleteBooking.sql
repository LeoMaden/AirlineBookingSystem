--
-- Delete a booking from the database using 
-- its unique Id.
--
CREATE PROCEDURE [dbo].[spDeleteBooking]
	@Id int
AS
	Delete From Bookings 
	Where Id = @Id;
RETURN 0
