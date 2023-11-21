using DBHelper.DataAccess;
using DBHelper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Data;
public class CompanyData : ICompanyData
{
    private readonly ISqlDataAccess _db;

    public CompanyData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task SaveCompanyDataAsync(CompanyModel company)
    {
        await _db.SaveDataAsync("spCompany_Insert", new
        {
            AccountId = company.AccountId,
            Code = company.Code,
            Description = company.Description,
            Industry = company.Industry,
            CycleId = company.CycleId,
            Created = company.Created,
            Modified = company.Modified
        });
    }
}
