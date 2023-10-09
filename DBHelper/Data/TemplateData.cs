using DBHelper.DataAccess;
using DBHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Data;
public class TemplateData : ITemplateData
{
	private readonly ISqlDataAccess _db;

	public TemplateData(ISqlDataAccess db)
	{
		_db = db;
	}
	public  Task SaveTemplateDataAsync(TemplateModel template) =>
		 _db.SaveDataAsync("dbo.spTemplate_Insert",
			new { template.EmployeeId, template.FID, template.Size, template.Valid, template.Template });
	public async Task<TemplateModel?> GetTemplatesAsync(int id)
	{
		var results = await _db.FetchData<TemplateModel?, dynamic>("spTemplate_Get", new { Id = id });
		return results.FirstOrDefault();
	}
}
