CREATE PROCEDURE [dbo].[spGetUsersByEmail]
	@Email nvarchar(150)
AS
	Select * from Users
	where Email = @Email;
RETURN 0
