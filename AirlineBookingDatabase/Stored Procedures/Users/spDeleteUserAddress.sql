CREATE PROCEDURE [dbo].[spDeleteUserAddress]
	@Id int
AS
	Delete from Addresses
	where Id = @Id;
RETURN 0
