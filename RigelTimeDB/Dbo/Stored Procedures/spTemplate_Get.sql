CREATE PROCEDURE [dbo].[spTemplate_Get]
	@EmployeeID int
AS
BEGIN
	SELECT EmployeeID FROM dbo.Template WHERE
	EmployeeId = @EmployeeID
END
