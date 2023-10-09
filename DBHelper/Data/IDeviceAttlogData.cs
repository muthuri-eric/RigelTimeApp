using DBHelper.Models;

namespace DBHelper.Data;
public interface IDeviceAttlogData
{
    Task<IEnumerable<DeviceAttlogInfoModel?>> GetDeviceAttlogInfoAsync();
    Task SaveDeviceAttlogInfoAsync(DeviceAttlogInfoModel deviceAttlogData);
}