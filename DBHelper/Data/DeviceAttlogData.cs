using DBHelper.DataAccess;
using DBHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Data;
public class DeviceAttlogData : IDeviceAttlogData
{
	private readonly ISqlDataAccess _db;

	public DeviceAttlogData(ISqlDataAccess db)
	{
		_db = db;
	}

	public async Task SaveDeviceAttlogInfoAsync(DeviceAttlogInfoModel deviceAttlogData) =>
		await _db.SaveDataAsync("spDeviceAttlogStamp_Insert", new
		{
			deviceAttlogData.SerialNumber,
			deviceAttlogData.Stamp,
			deviceAttlogData.NumberOfLines
		});
	public async Task<IEnumerable<DeviceAttlogInfoModel?>> GetDeviceAttlogInfoAsync() =>
		await _db.FetchData<DeviceAttlogInfoModel?, dynamic>("spDeviceAttlogStamp_Get", new { });
}
