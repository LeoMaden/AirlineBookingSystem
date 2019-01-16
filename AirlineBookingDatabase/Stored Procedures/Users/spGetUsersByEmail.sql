--
-- Get the users from the database
-- that have a specific email address.
--
-- Email should be unique so only 1 record
-- should be returned.
--
CREATE PROCEDURE [dbo].[spGetUsersByEmail]
	@Email nvarchar(150)
AS
	Select * from Users
	where Email = @Email;
RETURN 0
