CREATE PROCEDURE [dbo].[spDeviceAttlogStamp_Get]
AS
Begin
	SELECT Id, SerialNumber, Stamp, NumberOfLines
	From dbo.DeviceAttlogStamp
End
