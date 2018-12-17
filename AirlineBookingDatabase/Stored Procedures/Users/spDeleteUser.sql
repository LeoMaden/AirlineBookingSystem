CREATE PROCEDURE [dbo].[spDeleteUser]
	@Id int
AS
	Delete from Users
	where Id = @Id;
RETURN 0
