using DBHelper.Models;

namespace DBHelper.Data;
public interface ITemplateData
{
    Task SaveTemplateDataAsync(TemplateModel template);
    Task<TemplateModel?> GetTemplatesAsync(int id);
}