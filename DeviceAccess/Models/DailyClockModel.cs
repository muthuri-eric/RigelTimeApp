using DBHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigelTime.Models;
public class EmployeeDailyClockModel
{
    public int EmployeeId { get; set; }
    public DateTime ClocksDate { get; set; }
    public List<AttendanceModel> ClockList { get; set; }
}
