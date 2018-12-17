CREATE PROCEDURE [dbo].[spGetUserPasswordHash]
	@Id int
AS
	SELECT PasswordHash From Users
	where Id = @Id;
RETURN 0
