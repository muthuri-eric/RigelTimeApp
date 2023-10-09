
CREATE PROCEDURE [dbo].[SpEmployee_Insert]
	@EmployeeCode nvarchar(20),
	@EmployeeId int,
	@EmployeeName nvarchar(50),
	@IsDeviceSynced bit,
	@Templates int,
	@LastChanged datetime2
AS
if not exists
(
select EmployeeId FROM dbo.Employee Where EmployeeId = @EmployeeId
)
begin
	insert into dbo.Employee (EmployeeCode,	EmployeeId, EmployeeName, IsDeviceSynced, Templates, LastChanged)
	values(@EmployeeCode, @EmployeeId, @EmployeeName, @IsDeviceSynced, @Templates, @LastChanged)
end
else
begin
update dbo.Employee
Set EmployeeCode = @EmployeeCode,	EmployeeId = @EmployeeId, EmployeeName = @EmployeeName, 
IsDeviceSynced = @IsDeviceSynced, Templates = @Templates, LastChanged = @LastChanged 
where EmployeeId = @EmployeeId
end
