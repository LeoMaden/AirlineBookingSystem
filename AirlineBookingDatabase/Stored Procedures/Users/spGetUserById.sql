--
-- Get a user's details using their
-- unique Id.
--
CREATE PROCEDURE [dbo].[spGetUserById]
	@Id int
AS
	Select * from Users
	where Id = @Id;
RETURN 0
