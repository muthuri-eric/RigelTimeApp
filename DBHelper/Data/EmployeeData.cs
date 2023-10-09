using DBHelper.DataAccess;
using DBHelper.Models;

namespace DBHelper.Data;
public class EmployeeData : IEmployeeData
{
	private readonly ISqlDataAccess _db;

	public EmployeeData(ISqlDataAccess db)
	{
		_db = db;
	}
	public async Task SaveEmployeeDataAsync(EmployeeModel employee) =>
		await _db.SaveDataAsync("dbo.spEmployee_Insert", new
	{
		employee.EmployeeId,
		employee.EmployeeCode,
		employee.EmployeeName,
		employee.IsDeviceSynced,
		employee.Templates,
		employee.LastChanged
	});

	public async Task<IEnumerable<EmployeeModel?>> GetAllEmployeesAsync()
	{
		return await _db.FetchData<EmployeeModel?, dynamic>("spEmployee_GetAll", new { });
	}
	public async Task<EmployeeModel?> GetEmployeeByIdAsync(int employeeId)
	{
		var results = await _db.FetchData<EmployeeModel?, dynamic>("spEmployee_GetById", new { EmployeeId = employeeId });
		return results.FirstOrDefault();
	}
}
