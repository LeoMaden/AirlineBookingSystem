CREATE PROCEDURE [dbo].[spUpdateUserAddress]
	@Id int,
	@StreetAddress nvarchar(100),
	@Locality nvarchar(100),
	@City nvarchar(100),
	@Postcode nvarchar(10)
AS
	Update Addresses
	Set StreetAddress = @StreetAddress,
		Locality = @Locality,
		City = @City,
		Postcode = @Postcode
	Where Id = @Id;
RETURN 0
