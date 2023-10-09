using DBHelper.Data;
using DBHelper.Models;
using DeviceAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigelTimeAppService.DeviceAccess;
public class DbPush
{
    public PushManager PushManager { get; set; } = new();
    public async Task GetDeviceData(IDeviceData deviceData, IAttendanceData attendanceData, 
        IDeviceUserData deviceUserData, ITemplateData templateData, 
        IDeviceAttlogData deviceAttlogData, IEmployeeData employeeData)
    {
        await PushManager.PingDevice(deviceData, attendanceData, deviceUserData, 
            templateData, deviceAttlogData, employeeData);
        //Acquire the serial number of the device being communicated with

    }
    public async Task InsertDeviceData(DeviceModel device, IDeviceData deviceData)
    {
        await deviceData.DeviceDataAsync(device);
    }
}
