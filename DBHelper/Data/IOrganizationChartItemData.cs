using DBHelper.Models;

namespace DBHelper.Data;
public interface IOrganizationChartItemData
{
    Task<IEnumerable<OrganizationalChartItemModel?>> GetAllOrgChartItemsAsync();
    Task<IEnumerable<OrganizationalChartItemModel?>> GetOrgChartItemsByHeaderAsync(int orgChartHeaderId);
    Task<IEnumerable<OrganizationalChartItemModel?>> GetOrgChartItemsByIdAsync(int orgChartItemId);
    Task SaveOrganizationChartItemDataAsync(OrganizationalChartItemModel orgChartItem);
}