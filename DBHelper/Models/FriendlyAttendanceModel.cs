namespace DBHelper.Models;
public class FriendlyAttendanceModel
{
    public int AttendanceId { get; set; }
    public int EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public DateTime ClockDateTime { get; set; }
    public DateTime? Entry { get; set; }
    public DateTime? Exit { get; set; }
    public int Undefined { get; set; }
    public FriendlyAttendanceModel(AttendanceModel attendance, EmployeeModel? employee)
    {
        AttendanceId = attendance.AttendanceId;
        EmployeeName = employee?.EmployeeName;
        EmployeeId = attendance.EmployeeId;
        ClockDateTime = attendance.ClockDateTime;
        if(attendance.Status == 1)
        {
            Entry = null;
            Exit = attendance.ClockDateTime;
        }
        else if(attendance.Status == 0)
        {
            Entry = attendance.ClockDateTime;
            Exit = null;
        }
    }
}
