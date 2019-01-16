--
-- Insert a new user into the database.
--
-- The auto-generated Id of the user is assigned
-- to an output parameter
--
CREATE PROCEDURE [dbo].[spInsertUser]
    @Title NVARCHAR(10), 
    @FirstName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @UserName NVARCHAR(100), 
    @DateOfBirth DATE, 
    @Email NVARCHAR(150), 
    @PhoneNumber NVARCHAR(11), 
    @DateCreated DATE,
	@PasswordHash NVARCHAR(MAX),
	@Id int = 0 out
AS
	Insert into Users(Title, 
					  FirstName, 
					  LastName, 
					  UserName, 
					  DateOfBirth, 
					  Email, 
					  PhoneNumber, 
					  DateCreated,
					  PasswordHash)
	values(@Title, 
		   @FirstName, 
		   @LastName, 
		   @UserName, 
		   @DateOfBirth, 
		   @Email, 
		   @PhoneNumber, 
		   @DateCreated,
		   @PasswordHash);
	
	-- Set @Id to the Id of the record just inserted.
	select @Id = SCOPE_IDENTITY();
RETURN 0
