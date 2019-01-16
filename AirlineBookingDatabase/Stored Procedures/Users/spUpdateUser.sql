--
-- Update the user with the given Id to have 
-- fields that match the values given.
--
CREATE PROCEDURE [dbo].[spUpdateUser]
	@Id int,
    @Title NVARCHAR(10), 
    @FirstName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @UserName NVARCHAR(100), 
    @DateOfBirth DATE, 
    @Email NVARCHAR(150), 
    @PhoneNumber NVARCHAR(11),
	@PasswordHash NVARCHAR(MAX)
AS
	Update Users
	Set Title = @Title,
		FirstName = @FirstName,
		LastName = @LastName,
		UserName = @UserName,
		DateOfBirth = @DateOfBirth,
		Email = @Email,
		PhoneNumber = @PhoneNumber,
		PasswordHash = @PasswordHash
	Where Id = @Id;
RETURN 0
