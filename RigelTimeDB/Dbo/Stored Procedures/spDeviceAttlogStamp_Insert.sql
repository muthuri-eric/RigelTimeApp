CREATE PROCEDURE [dbo].[spDeviceAttlogStamp_Insert]
	@SerialNumber nvarchar(50),
	@Stamp nvarchar(50),
	@NumberOfLines int
AS
begin
	insert into dbo.DeviceAttlogStamp (SerialNumber, Stamp, NumberOfLines)
	values(@SerialNumber, @Stamp, @NumberOfLines)
end
