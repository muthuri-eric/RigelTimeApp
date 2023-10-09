using DBHelper.Models;

namespace DBHelper.Data;
public interface IEmployeeData
{
    Task<IEnumerable<EmployeeModel?>> GetAllEmployeesAsync();
    Task SaveEmployeeDataAsync(EmployeeModel employee);
    Task<EmployeeModel?> GetEmployeeByIdAsync(int employeeId);
}