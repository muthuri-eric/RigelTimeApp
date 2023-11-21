using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Models;
public class CompanyModel
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string Industry { get; set; }
    public int CycleId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }

}
