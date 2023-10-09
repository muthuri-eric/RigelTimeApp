CREATE PROCEDURE [dbo].[spDeviceUser_Insert]
	@EmployeeId int,
	@Name nvarchar(50),
	@Privilege nvarchar(50),
	@Group nvarchar(50),
	@Password nvarchar(50),
	@TimeZone nvarchar(50)
AS
begin
	insert into dbo.DeviceUser (EmployeeId, [Name], Privilege, [Group], Password, TimeZone)
	values(@EmployeeId, @Name, @Privilege,@Group, @Password, @TimeZone)
end
