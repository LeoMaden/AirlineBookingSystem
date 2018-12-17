CREATE PROCEDURE [dbo].[spGetUsersByName]
	@UserName nvarchar(100)
AS
	SELECT * from Users
	where UserName = @UserName;
RETURN 0
