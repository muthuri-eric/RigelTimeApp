using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Models;
public class OrganizationalChartItemModel
{
    public int Id { get; set; }
    public int OrganizationChartHeaderId { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}
