CREATE PROCEDURE [dbo].[spSetUserAddress]
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
		PostCode = @Postcode
	Where Id = @Id;
RETURN 0
