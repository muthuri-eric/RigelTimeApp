using DBHelper.Data;
using DBHelper.Models;
using DeviceAccess;
using RigelTimeAppService.DeviceAccess;

namespace RigelTimeAppService;

public class Worker : BackgroundService
{
    //private readonly ILogger<Worker> _logger;
    //private readonly PushManager _pushManager;

    public Worker(IDeviceData deviceData, IAttendanceData attendanceData, IDeviceUserData deviceUserData, 
        ITemplateData templateData, IDeviceAttlogData deviceAttlogData, IEmployeeData employeeData)
    {
        _deviceData = deviceData;
        _attendanceData = attendanceData;
        _deviceUserData = deviceUserData;
        _templateData = templateData;
        _deviceAttlogData = deviceAttlogData;
        _employeeData = employeeData;
    }
    DbPush push = new DbPush();
    DeviceModel device = new();
    private readonly IDeviceData _deviceData;
    private readonly IAttendanceData _attendanceData;
    private readonly IDeviceUserData _deviceUserData;
    private readonly ITemplateData _templateData;
    private readonly IDeviceAttlogData _deviceAttlogData;
    private readonly IEmployeeData _employeeData;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //await Task.Delay(1000, stoppingToken);

            await push.GetDeviceData(_deviceData, _attendanceData,_deviceUserData,
                _templateData, _deviceAttlogData, _employeeData);
            //device.SerialNumber = push.PushManager.DeviceSerialNumber;
            
            //device.Name = "MyTestDevice";
            //await push.InsertDeviceData(device, _deviceData);
        }
    }
    //public async Task InsertDeviceData(DeviceModel device, IDeviceData deviceData)
    //{
    //    await deviceData.DeviceDataAsync(device);
    //}
}
