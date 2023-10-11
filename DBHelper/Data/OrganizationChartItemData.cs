using DBHelper.DataAccess;
using DBHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Data;
public class OrganizationChartItemData : IOrganizationChartItemData
{
	private readonly ISqlDataAccess _db;

	public OrganizationChartItemData(ISqlDataAccess db)
	{
		_db = db;
	}
	public Task SaveOrganizationChartItemDataAsync(OrganizationalChartItemModel orgChartItem) =>
		_db.SaveDataAsync("spOrganizationChartItem_Insert", new
		{
			orgChartItem.Id,
			orgChartItem.OrganizationChartHeaderId,
			orgChartItem.Code,
			orgChartItem.Description
		});
	public async Task<IEnumerable<OrganizationalChartItemModel?>> GetAllOrgChartItemsAsync()
	{
		return await _db.FetchData<OrganizationalChartItemModel?, dynamic>("spOrganizationChartItem_GetAll", new { });
	}
	public async Task<IEnumerable<OrganizationalChartItemModel?>> GetOrgChartItemsByHeaderAsync(int orgChartHeaderId)
	{
		return await _db.FetchData<OrganizationalChartItemModel?, dynamic>("spOrganizationChartItem_GetByHeaderId", new { });
	}
	public async Task<IEnumerable<OrganizationalChartItemModel?>> GetOrgChartItemsByIdAsync(int orgChartItemId)
	{
		return await _db.FetchData<OrganizationalChartItemModel?, dynamic>("spOrganizationChartItem_GetById", new { });
	}
}
