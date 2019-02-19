CREATE PROCEDURE [dbo].[spGetAirportById]
	@Id int
AS
	Select * From Airports
	Where Id = @Id;
RETURN 0
