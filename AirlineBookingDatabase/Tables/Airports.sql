﻿CREATE TABLE [dbo].[Airports]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Code] NCHAR(3) NOT NULL, 
    [FriendlyName] NVARCHAR(100) NOT NULL
)
