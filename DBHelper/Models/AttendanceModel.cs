namespace DBHelper.Models;
public class AttendanceModel
{
    public int AttendanceId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime ClockDateTime { get; set; }
    public int Status { get; set; }
    public int Verify { get; set; }
    public int WorkCode { get; set; }
    public int Reserved1 { get; set; }
    public int Reserved2 { get; set; }
    public int DeviceId { get; set; }
}
