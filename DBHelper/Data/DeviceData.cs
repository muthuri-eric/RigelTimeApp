using DBHelper.DataAccess;
using DBHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Data;
public class DeviceData : IDeviceData
{
	private readonly ISqlDataAccess _db;

	public DeviceData(ISqlDataAccess db)
	{
		_db = db;
	}
	public Task DeviceDataAsync(DeviceModel device) =>
		_db.SaveDataAsync("dbo.spDevice_Insert",
			new { device.AccountId, device.TimeZone, device.SerialNumber, device.Name });
}
