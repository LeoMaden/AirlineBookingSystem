--
-- Delete a user's address from the database
-- using their unique Id.
--
CREATE PROCEDURE [dbo].[spDeleteUserAddress]
	@Id int
AS
	Delete from Addresses
	where Id = @Id;
RETURN 0
