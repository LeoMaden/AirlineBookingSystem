--
-- Get the address of a user using their
-- unique Id.
--
CREATE PROCEDURE [dbo].[spGetUserAddress]
	@Id int
AS
	SELECT * from Addresses
	where Id = @Id;
RETURN 0
