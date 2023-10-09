namespace DBHelper.Models;
public class EmployeeModel
{
    public int Id { get; set; } 
    public string EmployeeCode { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public bool IsDeviceSynced { get; set; } = false;
    public int Templates { get; set; }
    public DateTime LastChanged { get; set; }
}
