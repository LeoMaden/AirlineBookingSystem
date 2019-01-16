--
-- Get the users from the database
-- that have a specific username.
--
-- Username should be unique so only 1 record
-- should be returned.
--
CREATE PROCEDURE [dbo].[spGetUsersByName]
	@UserName nvarchar(100)
AS
	SELECT * from Users
	where UserName = @UserName;
RETURN 0
