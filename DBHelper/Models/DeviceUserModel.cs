namespace DBHelper.Models;
public class DeviceUserModel
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Privilege { get; set; }
    public int Group { get; set; }
    public string Password { get; set; }
    public int TimeZone { get; set; }
}
