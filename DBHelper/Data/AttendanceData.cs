using DBHelper.DataAccess;
using DBHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DBHelper.Data;
public class AttendanceData : IAttendanceData
{
	private readonly ISqlDataAccess _db;

	public AttendanceData(ISqlDataAccess db)
	{
		_db = db;
	}
	public Task SaveAttendanceDataAsync(AttendanceModel attendance) =>
		 _db.SaveDataAsync("dbo.spAttendance_Insert",
			new { attendance.EmployeeId, attendance.ClockDateTime, attendance.Status, 
				attendance.Verify, attendance.WorkCode, attendance.Reserved1, attendance.Reserved2, attendance.DeviceId });
	public async Task<IEnumerable<AttendanceModel?>> GetAllAttendanceAsync()
	{
		return await _db.FetchData<AttendanceModel?, dynamic>("dbo.spAttendance_GetAll", new { });
	}
	public async Task<IEnumerable<AttendanceModel?>> GetAttendanceByIdAsync(int employeeId)
	{
		return await _db.FetchData<AttendanceModel?, dynamic>($"select * from dbo.Attendance where EmployeeId = {employeeId}");
	}
}
