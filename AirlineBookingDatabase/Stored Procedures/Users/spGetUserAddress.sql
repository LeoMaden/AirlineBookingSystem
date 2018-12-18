CREATE PROCEDURE [dbo].[spGetUserAddress]
	@Id int
AS
	SELECT * from Addresses
	where Id = @Id;
RETURN 0
