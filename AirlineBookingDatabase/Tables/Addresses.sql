CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [StreetAddress] NVARCHAR(100) NOT NULL, 
    [Locality] NVARCHAR(100) NULL, 
    [City] NVARCHAR(100) NULL, 
    [Postcode] NVARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Addresses_Users] FOREIGN KEY (Id) REFERENCES Users(Id)
)
