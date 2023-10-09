CREATE PROCEDURE [dbo].[spAttendance_Insert]
	@EmployeeId int,
	@ClockDateTime datetime2, 
	@Status int,
	@Verify int,
	@WorkCode int,
	@Reserved1 int,
	@Reserved2 int,
	@DeviceID int
AS
IF NOT EXISTS
(
select * from dbo.Attendance where EmployeeId = @EmployeeId and ClockDateTime = @ClockDateTime
)
begin
	insert into dbo.Attendance (EmployeeId, ClockDateTime, [Status], Verify, WorkCode, Reserved1, Reversed2, DeviceID)
	values(@EmployeeId, @ClockDateTime, @Status, @Verify, @WorkCode, @Reserved1, @Reserved2, @DeviceID)
end
