using DBHelper.DataAccess;
using DBHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Data;
public class DeviceUserData : IDeviceUserData
{
	private readonly ISqlDataAccess _db;

	public DeviceUserData(ISqlDataAccess db)
	{
		_db = db;
	}
	public async Task SaveDeviceUserDataAsync(DeviceUserModel deviceUser) =>
		await _db.SaveDataAsync("dbo.spDeviceUser_Insert",
			new
			{
				deviceUser.Name,
				deviceUser.Privilege,
				deviceUser.Group,
				deviceUser.EmployeeId,
				deviceUser.TimeZone,
				deviceUser.Password
			});
}
