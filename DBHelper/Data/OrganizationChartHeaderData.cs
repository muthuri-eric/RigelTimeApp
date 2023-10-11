using DBHelper.DataAccess;
using DBHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Data;
public class OrganizationChartHeaderData : IOrganizationChartHeaderData
{
	private readonly ISqlDataAccess _db;
	public OrganizationChartHeaderData(ISqlDataAccess db)
	{
		_db = db;
	}
	public async Task SaveOrganizationalChartHeaderAsync(OrganizationalChartHeaderModel orgChartHeader)
	{
		await _db.SaveDataAsync("spOrganizationChartHeader_Insert", new
		{
			orgChartHeader.Id,
			orgChartHeader.Code,
			orgChartHeader.Description
		});
	}
	public async Task<IEnumerable<OrganizationalChartHeaderModel?>> GetAllChartHeadersAsync()
	{
		return await _db.FetchData<OrganizationalChartHeaderModel?, dynamic>("spOrganizationChartHeader_GetAll", new { });
	}
	public async Task<IEnumerable<OrganizationalChartHeaderModel?>> GetChartHeadersById(int orgChartHeaderId)
	{
		return await _db.FetchData<OrganizationalChartHeaderModel?, dynamic>(
			$"select * from dbo.OrganizationChartHeader where OrganizationChartHeaderId = {orgChartHeaderId}");
	}
}
