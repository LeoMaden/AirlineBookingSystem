--
-- Insert a new booking into the database.
--
-- The auto-generated Id of the user is assigned
-- to an output parameter
--
CREATE PROCEDURE [dbo].[spInsertBooking]
    @BookingReference NCHAR(10), 
	@UserId int,
	@OutFlight int,
	@InFlight int,
	@NumberAdults int,
	@NumberChildren int,
	@TravelClass nvarchar(50),
	@Last4CardDigits nchar(4),
	@CardType nvarchar(50),
	@Price money,
	@DateTimeCreated datetime,
	@Id int = 0 out
AS
	Insert into Bookings(BookingReference, 
						UserId, 
						OutFlight, 
						InFlight, 
						NumberAdults, 
						NumberChildren, 
						TravelClass, 
						Last4CardDigits,
						CardType,
						Price,
						DateTimeCreated)
	values(@BookingReference, 
		   @UserId, 
		   @OutFlight, 
		   @InFlight, 
		   @NumberAdults, 
		   @NumberChildren, 
		   @TravelClass, 
		   @Last4CardDigits,
		   @CardType,
		   @Price,
		   @DateTimeCreated);
	
	-- Set @Id to the Id of the record just inserted.
	select @Id = SCOPE_IDENTITY();
RETURN 0
