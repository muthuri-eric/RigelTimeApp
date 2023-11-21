using DBHelper.Models;

namespace DBHelper.Data;
public interface ICompanyData
{
    Task SaveCompanyDataAsync(CompanyModel company);
}