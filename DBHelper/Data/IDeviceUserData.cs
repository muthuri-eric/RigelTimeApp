using DBHelper.Models;

namespace DBHelper.Data;
public interface IDeviceUserData
{
    Task SaveDeviceUserDataAsync(DeviceUserModel deviceUser);
}