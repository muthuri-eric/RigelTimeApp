using DBHelper.Models;

namespace DBHelper.Data;
public interface IOrganizationChartHeaderData
{
    Task<IEnumerable<OrganizationalChartHeaderModel?>> GetAllChartHeadersAsync();
    Task<IEnumerable<OrganizationalChartHeaderModel?>> GetChartHeadersById(int orgChartHeaderId);
    Task SaveOrganizationalChartHeaderAsync(OrganizationalChartHeaderModel orgChartHeader);
}