--
-- Get a booking with the specified booking
-- reference number.
--
CREATE PROCEDURE [dbo].[spGetBookingByReference]
	@BookingReference nchar(10)
AS
	Select * From Bookings
	Where BookingReference = @BookingReference;
RETURN 0
