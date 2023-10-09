CREATE PROCEDURE [dbo].[spDevice_Insert]
	@SerialNumber nvarchar(50),
	@Name nvarchar(50),
	@TimeZone nvarchar(50),
	@AccountId nvarchar(50)
AS
BEGIN
 insert into dbo.Device (SerialNumber, Name, TimeZone, AccountID)
 values(@SerialNumber, @Name, @TimeZone,@AccountId)
END
