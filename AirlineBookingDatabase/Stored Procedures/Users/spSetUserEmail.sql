CREATE PROCEDURE [dbo].[spSetUserEmail]
	@Id int,
	@Email nvarchar(150)
AS
	Update Users
	set Email = @Email
	where Id = @Id;
RETURN 0
