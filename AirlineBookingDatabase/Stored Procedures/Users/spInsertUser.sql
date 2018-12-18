CREATE PROCEDURE [dbo].[spInsertUser]
    @Title NVARCHAR(10), 
    @FirstName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @UserName NVARCHAR(100), 
    @DateOfBirth DATE, 
    @Email NVARCHAR(150), 
    @PhoneNumber NVARCHAR(11), 
    @DateCreated DATE,
	@Id int = 0 out
AS
	Insert into Users(Title, 
					  FirstName, 
					  LastName, 
					  UserName, 
					  DateOfBirth, 
					  Email, 
					  PhoneNumber, 
					  DateCreated)
	values(@Title, 
		   @FirstName, 
		   @LastName, 
		   @UserName, 
		   @DateOfBirth, 
		   @Email, 
		   @PhoneNumber, 
		   @DateCreated);
	
	--Set @Id to the id of the record just inserted.
	select @Id = SCOPE_IDENTITY();
RETURN 0
