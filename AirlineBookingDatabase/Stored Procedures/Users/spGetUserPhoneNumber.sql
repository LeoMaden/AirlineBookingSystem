CREATE PROCEDURE [dbo].[spGetUserPhoneNumber]
	@Id int
AS
	SELECT PhoneNumber from Users
	where Id = @Id;
RETURN 0
