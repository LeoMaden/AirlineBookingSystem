CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(10) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [UserName] NVARCHAR(100) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Email] NVARCHAR(150) NOT NULL, 
    [PhoneNumber] NVARCHAR(11) NOT NULL, 
    [DateCreated] DATE NOT NULL, 
    [PasswordHash] NVARCHAR(MAX) NULL
)
