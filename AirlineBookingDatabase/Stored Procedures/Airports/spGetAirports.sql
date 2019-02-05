--
-- Get all the airports in the database.
--
CREATE PROCEDURE [dbo].[spGetAirports]
AS
	Select * From Airports;
RETURN 0
