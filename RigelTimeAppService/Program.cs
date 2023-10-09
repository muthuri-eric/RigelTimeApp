using DBHelper.Data;
using DBHelper.DataAccess;
using DeviceAccess;
using RigelTimeAppService;
using RigelTimeAppService.DeviceAccess;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<PushManager>();
        services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        services.AddSingleton<IDeviceData, DeviceData>();
        services.AddSingleton<IAttendanceData, AttendanceData>();
        services.AddSingleton<IDeviceUserData, DeviceUserData>();
        services.AddSingleton<ITemplateData, TemplateData>();
        services.AddSingleton<IDeviceAttlogData, DeviceAttlogData>();
        services.AddSingleton<IEmployeeData, EmployeeData>();

    })
    .Build();

await host.RunAsync();
