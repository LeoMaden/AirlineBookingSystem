CREATE PROCEDURE [dbo].[spGetUserEmail]
	@Id int
AS
	SELECT Email From Users
	where Id = @Id;
RETURN 0
