CREATE PROCEDURE [dbo].[spInsertUserAddress]
	@Id int,
	@StreetAddress nvarchar(100),
	@Locality nvarchar(100),
	@City nvarchar(100),
	@Postcode nvarchar(10)
AS
	Insert into Addresses(Id, StreetAddress, Locality, City, Postcode)
	values(@Id, @StreetAddress, @Locality, @City, @Postcode);
RETURN 0
