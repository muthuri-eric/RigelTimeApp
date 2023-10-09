using DBHelper.Models;

namespace DBHelper.Data;
public interface IDeviceData
{
    Task DeviceDataAsync(DeviceModel device);
}