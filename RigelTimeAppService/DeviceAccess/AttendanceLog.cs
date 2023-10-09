using DBHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigelTimeAppService.DeviceAccess;
public class AttendanceLog
{
    public string Stamp { get; set; }
    public List<string> Attlog { get; set; } = new();

    public AttendanceModel Attendance { get; set; } = new();

    public List<AttendanceModel> AttlogFull { get; set; } = new();

    public void FetchAttlogLineItems(string data)
    {
        var attlogItems = data.Split("\n").ToList();

        foreach(var attlogItem in attlogItems)
        {
            if(attlogItem != String.Empty)
            {
                var attlogItemItems = attlogItem.Split("\t");
                Attendance.EmployeeId = Convert.ToInt32(attlogItemItems[0]);
                Attendance.ClockDateTime = Convert.ToDateTime(attlogItemItems[1]);
                Attendance.Status = Convert.ToInt32(attlogItemItems[2]);
                Attendance.Verify = Convert.ToInt32(attlogItemItems[3]);
                Attendance.WorkCode = Convert.ToInt32(attlogItemItems[4]);
                //Attendance.Reserved1 = Convert.ToInt32(attlogItemItems[5]);
                //Attendance.Reserved2 = Convert.ToInt32(attlogItemItems[6]);
                Attlog.Add(attlogItem);
                AttlogFull.Add(Attendance);
            }

        } 
    }
}
