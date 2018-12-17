CREATE PROCEDURE [dbo].[spSetUserPasswordHash]
	@Id int,
	@PasswordHash nvarchar(MAX)
AS
	Update Users
	set PasswordHash = @PasswordHash
	where Id = @Id;
RETURN 0
