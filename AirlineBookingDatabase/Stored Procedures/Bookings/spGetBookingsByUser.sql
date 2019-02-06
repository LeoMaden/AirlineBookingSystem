--
-- Get the bookings for a specific user
-- using their Id.
--
CREATE PROCEDURE [dbo].[spGetBookingsByUser]
	@UserId int
AS
	Select [Id], 
		[BookingReference], 
		[Last4CardDigits], 
		[CardType], 
		[DateTimeCreated], 
		[UserId], 
		[NumberAdults], 
		[NumberChildren], 
		[TravelClass], 
		[Price]
	From Bookings
	Where UserId = @UserId;

	-- Select the in and out flight ids foreach booking.
	select Id, OutFlight, InFlight
	from Bookings
	where UserId = @UserId;
RETURN 0
