CREATE PROCEDURE [dbo].[spSetUserPhoneNumber]
	@Id int,
	@PhoneNumber nvarchar(11)
AS
	Update Users
	set PhoneNumber = @PhoneNumber
	where Id = @Id;
RETURN 0
