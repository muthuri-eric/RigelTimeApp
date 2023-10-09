CREATE PROCEDURE [dbo].[spEmployee_GetById]
	@EmployeeId int
AS
begin
	SELECT EmployeeCode, EmployeeId, EmployeeName, IsDeviceSynced, Templates
	FROM dbo.Employee
	Where EmployeeId = @EmployeeId
END
