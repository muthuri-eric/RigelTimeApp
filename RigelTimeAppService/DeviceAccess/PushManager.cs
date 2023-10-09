using DBHelper.Data;
using DBHelper.DataAccess;
using DBHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DeviceAccess;
public class PushManager
{
    private HttpListener _httpListener = new();
    //private readonly Push _push;

    Push _push = new Push();
    public string DeviceSerialNumber { get; private set; }
    public HashSet<string> serialNumbers { get; set; }
    private readonly object _lockRequest = new object();
    //   public PushManager(HttpListener httpListener)
    //{
    //	_httpListener = httpListener;
    //	//_push = push;
    //}
    List<string> deviceCommands = new();
    bool querySent = false;
	public async Task PingDevice(IDeviceData deviceData, IAttendanceData attendanceData,
        IDeviceUserData deviceUserData, ITemplateData templateData, 
        IDeviceAttlogData deviceAttlogData, IEmployeeData employeeData)
	{
		_httpListener.Prefixes.Add("http://*:8083/");
		_httpListener.Start();
        //implement logic to check whether there is data to send to device. 
		await ListenAsync(deviceData, attendanceData, deviceUserData, templateData, deviceAttlogData, employeeData);
	}
	private async Task ListenAsync(IDeviceData deviceData, IAttendanceData attendanceData, 
        IDeviceUserData deviceUserData, ITemplateData templateData, 
        IDeviceAttlogData deviceAttlogData, IEmployeeData employeeData)
	{
        
        while (true)
		{
            try
            {
                List<EmployeeModel> employeesTosend = new();
                var employeesToUpdate = await employeeData.GetAllEmployeesAsync();
                if (!querySent)
                {
                    StringBuilder sb = new();
                    foreach (var employeeToUpdate in employeesToUpdate)
                    {                        
                        int i = 1;
                        if (employeeToUpdate.IsDeviceSynced == false)
                        {
                            employeeToUpdate.IsDeviceSynced = true;
                            employeesTosend.Add(employeeToUpdate);
                            //sb.AppendLine("C:1:INFO");
                            sb.AppendLine($"C:{i}:DATA UPDATE USERINFO PIN={employeeToUpdate.EmployeeId} \tName={employeeToUpdate.EmployeeName}");
                            i++;
                            querySent = false;
                        }
                        else
                        {
                            querySent = true;
                        }
                    }
                    deviceCommands.Add(sb.ToString());
                    querySent = false;
                }
                //else
                //{
                //    StringBuilder sb = new StringBuilder();
                //    sb.AppendLine("OK");
                //    deviceCommands.Add(sb.ToString());
                //}
                if (deviceCommands.Contains(""))
                {
                    deviceCommands.Clear();
                }

                var context = await _httpListener.GetContextAsync();


                DeviceSerialNumber = context.Request.QueryString["SN"];
                if (string.IsNullOrWhiteSpace(DeviceSerialNumber))
                {
                    return;
                }
                _push = new(DeviceSerialNumber);
                
                lock (_lockRequest)
                {
                    Task.Run(() => _push.ProcessRequest(context, deviceData, attendanceData, deviceUserData, 
                        templateData, deviceAttlogData, employeeData, deviceCommands));
                }
                //querySent = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
