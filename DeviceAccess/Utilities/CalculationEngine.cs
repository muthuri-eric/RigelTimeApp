using DBHelper.Data;
using DBHelper.Models;
using RigelTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigelTime.Utilities;
public class CalculationEngine
{
    private List<AttendanceModel> attendance;
    private List<DateTime> dailyClocks;
    private DateTime firstClock;
    private DateTime lastClock;
    public void Calculate(List<EmployeeDailyClockModel> dayClocks)
    {
        foreach(EmployeeDailyClockModel employeeDailyClock in dayClocks)
        {
            attendance = employeeDailyClock.ClockList;
            foreach(AttendanceModel clocks in attendance)
            {
                dailyClocks.Add(clocks.ClockDateTime);
            }
        }
    }
}
