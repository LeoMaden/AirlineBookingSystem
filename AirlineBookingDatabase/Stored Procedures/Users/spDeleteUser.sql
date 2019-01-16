--
-- Delete a user from the database using 
-- their unique Id.
--
CREATE PROCEDURE [dbo].[spDeleteUser]
	@Id int
AS
	Delete from Users
	where Id = @Id;
RETURN 0
