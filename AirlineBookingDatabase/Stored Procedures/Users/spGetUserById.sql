CREATE PROCEDURE [dbo].[spGetUserById]
	@Id int
AS
	Select * from Users
	where Id = @Id;
RETURN 0
